using EventReg.API.Model;
using EventReg.API.Wrappers;
using EventReg.API.ViewModel.InputViewModel;
using EventReg.API.ViewModel.OutputViewModel;
using EventReg.Common;
using EventReg.Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventReg.API.Controllers
{
    [ApiController]
    [Route("api/events")]
    [AllowAnonymous]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventRegiseterService _eventRegiseterService;
        private readonly IMemoryCache _memoryCache;
        public EventController(ILogger<EventController> logger, IEventRegiseterService eventRegiseterService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _eventRegiseterService = eventRegiseterService;
            _memoryCache = memoryCache;
        }
     
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllEvents()

        {
            try
            {
                var cacheKey = "eventList";               
                if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<EventOutputView> events))
                {
                    //calling the server
                    IEnumerable<IEvent> eventList = await _eventRegiseterService.GetActiveEvents();
                    events = eventList.Select(i => new EventOutputView() { Name = i.Name, Id = i.Id, Description = i.Description }).Distinct().OrderByDescending(i => i.Name).ToList();

                    MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(25), // cache will expire in 25 seconds
                        SlidingExpiration = TimeSpan.FromSeconds(5) // caceh will expire if inactive for 5 seconds
                    };

                    _memoryCache.Set(cacheKey, eventList, options);
                }
               

                _logger.LogInformation($"Returned events from the database.");

                return Ok(Response<IEnumerable<object>>.Success(events));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the ReadAll action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from  database"));

            }
        }
        [HttpGet("getEventDetail/{eventId}")]
        public async Task<IActionResult> GetEventDetail(long eventId)

        {
            try
            {
                _logger.LogInformation($"Returned GetEventDetail from the database.");
                IEvent currentEvent = await _eventRegiseterService.GetEventDetail(eventId);
                return Ok(Response<IEvent>.Success(new Event(currentEvent)));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetEventDetail action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from  database"));

            }
        }
        [HttpPost("register")]

        public async Task<IActionResult> registerEvent([FromBody] RegistrationInputView registration)
        {
            try
            {

                _logger.LogInformation($"Created registration:{registration.EventId + "," + registration.Email}");

                var eventNamesCookieKeys = Request.Cookies.Keys.ToList();

                if (registration == null|| registration.EventId==0 )
                {
                    return BadRequest(Response<string>.Fail("The registration is empty "));
                }
                if (String.IsNullOrEmpty( registration.PhoneNumber) && String.IsNullOrEmpty(registration.Email) )
                {
                    return BadRequest(Response<string>.Fail("At least email or phone should be provided."));
                }
                // to make sure that one person cannot be registered multiple times to the same event.
                // by phone number or email and finally using cookie keys
                bool isRegisteredBefore = await isRegisteredBeforeToTheEvent(eventNamesCookieKeys, registration);
                if (isRegisteredBefore)
                    return BadRequest(Response<string>.Fail("Already registered "));

                //One person cannot be registered multiple times to the same event.
                bool isExpiredevent = await _eventRegiseterService.IsExpiredevent( registration.EventId);
                if (isExpiredevent)
                    return BadRequest(Response<string>.Fail("This event is expired "));

                IRegistration insertedRegistration = await _eventRegiseterService.RegisterEvent(new Registration(registration));

                // to make sure that one person cannot be registered multiple times to the same event.
                // add cookie with event name 
                var option = new CookieOptions();
                option.Expires = insertedRegistration.CreatedEevnt.EndDateTime;  
                Response.Cookies.Append(insertedRegistration.CreatedEevnt.Name, insertedRegistration.TicketNumber);
                return Ok(Response<string>.Success(insertedRegistration.TicketNumber));


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the registerEvent action: {ex}");

                return StatusCode(500, Response<string>.Fail("Error retrieving data from the memory database"));

            }
        }

        private async Task<bool> isRegisteredBeforeToTheEvent(List<string> eventNamesCookieKeys, RegistrationInputView registration)
        {
            // if the user uses the same phone or email to register to the event he already registerd
            bool isRegisteredBefore = await _eventRegiseterService.RegisteredBefore(new Registration(registration));
            if(!isRegisteredBefore)
            {
                var currentEvent = await _eventRegiseterService.GetEventDetail(registration.EventId);
                isRegisteredBefore = eventNamesCookieKeys.Contains(currentEvent.Name);
            }
            return isRegisteredBefore;
        }
    }
}
