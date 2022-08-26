using EventReg.API.ViewModel.InputViewModel;
using EventReg.Common.Contracts;
using System.Runtime.Serialization;

namespace EventReg.API.Model
{
    [DataContract(Name = "registration")]
    public class Registration:IRegistration
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "ticketNumber")]
        public string TicketNumber { get; set; }
        [DataMember(Name = "eventId")]
        public long EventId { get; set; }
        [IgnoreDataMember]
        public IEvent CreatedEevnt { get; set; }

      public Registration(RegistrationInputView registration)
        {
            EventId=registration.EventId;
            Email=registration.Email;
            PhoneNumber=registration.PhoneNumber;
                
        }
        public Registration(IRegistration registration)
        {
            EventId = registration.EventId;
            Email = registration.Email;
            PhoneNumber = registration.PhoneNumber;
            CreatedEevnt = registration.CreatedEevnt;
            TicketNumber=registration.TicketNumber;
            Id=registration.Id;

        }
    }
}
