using EventReg.Common.Contracts;
using EventReg.Common;
using EventReg.Common.Filter;
using EventReg.Data.Model;
using EventReg.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventReg.Data.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly EventDBContext _context;
        public RegistrationRepository(EventDBContext context)
        {
            this._context = context;
        }
        public async Task<IRegistration> RegisterEvent(IRegistration registration)
        {
               Registration insertedReg = new Registration();
                insertedReg.EventId= registration.EventId; ;
                insertedReg.Email= registration.Email;
                insertedReg.TicketNumber= registration.TicketNumber;
                insertedReg.PhoneNumber= registration.PhoneNumber;
                    _context.Registrations.Add(insertedReg);
                int returnNumber = await _context.SaveChangesAsync();
                if (returnNumber == 1)
                {

                    return await GetRegistrationById(insertedReg.Id);
                }
                else
                    return null;
            
           
        }
        private async Task<IRegistration> GetRegistrationById(long id)
        {
            return await _context.Registrations.Include(s=>s.EventRegisteration).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<bool> RegisteredBefore(IRegistration registration)
        {
            return await _context.Registrations.AnyAsync(s=>s.EventId==registration.EventId&&s.Email!=null&&s.PhoneNumber!=null&&(s.Email==registration.Email||s.PhoneNumber==registration.PhoneNumber));
        }
        public async Task<bool> RegisteredBefore(List<string> eventNames)
        {
            return await _context.Events.AnyAsync(s=>eventNames.Contains(s.Name));
        }
      
        public async Task<IEnumerable<IRegistration>> GetRegistrationsDetail(long eventId, PaginationFilter validFilter)
        {
            _context.Database.CanConnect();
            return await _context.Registrations.Where(s => s.EventId==eventId)
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize).ToListAsync();
        }
        

        
    }
}
