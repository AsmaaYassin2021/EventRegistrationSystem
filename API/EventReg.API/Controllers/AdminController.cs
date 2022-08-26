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
using EventReg.Common.Filter;
using EventReg.API.Authentication;
using EventReg.API.Model;

namespace EventReg.API.Controllers
{
   // [Authorize]
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IEventRegiseterService _eventRegiseterService;
        private readonly IMemoryCache _memoryCache;
        private readonly ITokenAuth _jwtAuth;
        public AdminController(ILogger<AdminController> logger, IEventRegiseterService eventRegiseterService, IMemoryCache memoryCache, ITokenAuth jwtAuth)
        {
            _logger = logger;
            _eventRegiseterService = eventRegiseterService;
            _memoryCache = memoryCache;
          _jwtAuth = jwtAuth;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllEvents(DateTime? fromDate, DateTime? toDate)

        {
            try
            {
                IEnumerable<IEvent> eventList = await _eventRegiseterService.GetActiveEventsAndExpiredEvents(fromDate, toDate);
                IEnumerable<EventOutputView> events = eventList.Select(i => new EventOutputView() { Name = i.Name, Id = i.Id, Description = i.Description }).Distinct().OrderByDescending(i => i.Name).ToList();
                _logger.LogInformation($"Returned events from the database.");
                return Ok(Response<IEnumerable<EventOutputView>>.Success(events));

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
                _logger.LogInformation($"Returned GetEventDetail from the database."+eventId);
                IEvent currentEvent = await _eventRegiseterService.GetEventDetail(eventId);                
                if (currentEvent != null)
                    return Ok(Response<IEvent>.Success(new Event(currentEvent)));
                else
                    return BadRequest(Response<string>.Fail("The event is expired"));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetEventDetail action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from  database"));

            }
        }

        [HttpGet("getRegistrationsDetail/{eventId}")]
        public async Task<IActionResult> getRegistrationsDetail([FromQuery] PaginationFilter filter, long eventId)

        {
            try
            {
                
                _logger.LogInformation($"Returned GetEventDetail from the database.");
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                IEnumerable<IRegistration> pagedData = await _eventRegiseterService.GetRegistrationsDetail(eventId, validFilter);
                return Ok(Response<IEnumerable<IRegistration>>.Success(pagedData.Select(s => new Registration(s))));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the ReadAll action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from  database"));

            }
        }
       
        
        [AllowAnonymous]     
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] User userCredential)
        {
            _logger.LogInformation($" Authentication for the user."+" " +userCredential.UserName);
            bool isUserCredentialCorrect = await _eventRegiseterService.Login(userCredential.UserName,userCredential.Password);
            if (isUserCredentialCorrect)
            {
                var token = _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
                if (token == null)
                    return Unauthorized(Response<string>.Fail("User name or password is incorrect "));
                return Ok(Response<string>.Success(token));
            }
            else
                return Unauthorized(Response<string>.Fail("User name or password is incorrect "));
        }
    }
}
