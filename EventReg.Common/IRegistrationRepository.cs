using EventReg.Common.Contracts;
using EventReg.Common.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventReg.Common
{
    public interface IRegistrationRepository
    {
        Task<IRegistration> RegisterEvent(IRegistration registration);
        Task<IEnumerable<IRegistration>> GetRegistrationsDetail(long eventId, PaginationFilter validFilter);
        Task<bool> RegisteredBefore(IRegistration registration);
        Task<bool> RegisteredBefore(List<string> eventNames);
    }
}
