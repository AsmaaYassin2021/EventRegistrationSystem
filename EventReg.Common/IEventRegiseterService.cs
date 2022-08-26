using EventReg.Common.Contracts;
using EventReg.Common.Filter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventReg.Common
{
    public interface IEventRegiseterService
    {
        Task<IEnumerable<IEvent>> GetActiveEvents();   
        Task<IEnumerable<IEvent>> GetActiveEventsAndExpiredEvents(DateTime? fromDate, DateTime? toDate);
        Task<IEvent> GetEventDetail(long eventId);
        Task<IEnumerable<IRegistration>> GetRegistrationsDetail(long eventId, PaginationFilter validFilter);
        Task<IRegistration> RegisterEvent(IRegistration registration);
        Task<bool> Login(string name,string password);
        Task<bool> RegisteredBefore(IRegistration registration);
        Task<bool> RegisteredBefore(List<string> eventNames);
        Task<bool> IsExpiredevent(long eventId);
    }
}