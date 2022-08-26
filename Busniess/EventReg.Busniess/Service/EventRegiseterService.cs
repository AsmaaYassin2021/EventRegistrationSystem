
using EventReg.Common;
using EventReg.Common.Contracts;
using EventReg.Common.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventReg.Busniess.Service
{
    public class EventRegiseterService : IEventRegiseterService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRegistrationRepository _registrationRepository;
        public EventRegiseterService(IEventRepository eventRepository, IUserRepository userRepository, IRegistrationRepository registrationRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _registrationRepository = registrationRepository;
        }

        public async Task<IEvent> GetEventDetail(long eventId)
        {
            return await _eventRepository.GetEventDetail(eventId);
        }

        public async Task<IEnumerable<IEvent>> GetActiveEvents()
        {
          return await _eventRepository.GetActiveEvents();
        }
        public async Task<IEnumerable<IEvent>> GetActiveEventsAndExpiredEvents(DateTime? fromDate, DateTime? toDate)
        {
            return await _eventRepository.GetActiveEventsAndExpiredEvents(fromDate,toDate);
        }
        public async Task<bool> Login(string name, string password)
        {
            return await _userRepository.Login(name,password);
        }
        public async Task<bool> RegisteredBefore(IRegistration registration)
        {
            return await _registrationRepository.RegisteredBefore(registration);
        }
        public async Task<bool> IsExpiredevent(long eventId)
        {
            return await _eventRepository.IsExpiredevent(eventId);
        }
        public async Task<bool> RegisteredBefore(List<string> eventNames)
        {
            return await _registrationRepository.RegisteredBefore(eventNames);
        }
        public async Task<IRegistration> RegisterEvent(IRegistration registration)
        {

            registration.TicketNumber = registration.TicketNumber.gen_Digits(6);
            return  await _registrationRepository.RegisterEvent(registration);
        }

        public async Task<IEnumerable<IRegistration>> GetRegistrationsDetail(long eventId, PaginationFilter validFilter)
        {
            return await _registrationRepository.GetRegistrationsDetail(eventId, validFilter);
        }
       
        
    }
}
