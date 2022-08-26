using EventReg.Common.Contracts;
using EventReg.Common.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventReg.Common
{
    public interface IEventRepository
    {
        Task<IEnumerable<IEvent>> GetActiveEvents();
        Task<IEvent> GetEventDetail(long eventId );
        Task<IEnumerable<IEvent>> GetActiveEventsAndExpiredEvents(DateTime? fromDate, DateTime? toDate);
        Task<bool> IsExpiredevent(long eventId);
       
    }
}
