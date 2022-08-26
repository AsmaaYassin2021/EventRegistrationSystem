using EventReg.Common.Contracts;
using EventReg.Common;
using EventReg.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventReg.Common.Filter;

namespace EventReg.Data.Repository
{
    public class EventRepository: IEventRepository
    {
        private readonly EventDBContext _context;
        public EventRepository(EventDBContext context)
        {
            this._context = context;
        }

        public async Task<IEvent> GetEventDetail(long eventId)
        {
            _context.Database.CanConnect();
            return await _context.Events.FirstOrDefaultAsync(e=>e.Id == eventId);
        }

        public async Task<IEnumerable<IEvent>> GetActiveEvents()
        {
            _context.Database.CanConnect();
            return await _context.Events.Where(s=>s.StartDateTime>=DateTime.Now).ToListAsync();
        }
        public async Task<bool> IsExpiredevent(long eventID)
        {
            return await _context.Events.AnyAsync(s => s.Id ==eventID&&s.StartDateTime <= DateTime.Now);
        }
        public async Task<IEnumerable<IEvent>> GetActiveEventsAndExpiredEvents(DateTime? fromDate, DateTime? toDate)
        {
            _context.Database.CanConnect();
            if(fromDate.HasValue && !toDate.HasValue)
            return await _context.Events.Where(s=>s.StartDateTime>=fromDate.Value).ToListAsync();
            else if(toDate.HasValue&&!fromDate.HasValue)
                return await _context.Events.Where(s => s.EndDateTime <= toDate.Value).ToListAsync();
            else if (toDate.HasValue && fromDate.HasValue)
                return await _context.Events.Where(s => s.StartDateTime >= fromDate.Value&&s.EndDateTime<=toDate).ToListAsync();
            else
                return await _context.Events.ToListAsync();
        }
       
    }
}
