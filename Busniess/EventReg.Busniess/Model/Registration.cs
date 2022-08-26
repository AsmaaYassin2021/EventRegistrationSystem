using EventReg.Common.Contracts;

namespace EventReg.Busniess.Model
{
    public class Registration:IRegistration
    {
        private readonly IRegistration registration;

        public Registration(IRegistration registration)
        {
            this.registration = registration;
        }

        public long Id { get; set; }       
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TicketNumber { get; set; }
        public long EventId { get; set; }

        public IEvent CreatedEevnt { get; set; }
    }
}
