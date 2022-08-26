using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace EventReg.API.ViewModel.InputViewModel
{
    [DataContract(Name = "registrationView")]
    public class RegistrationInputView
    {
        [DataMember(Name = "eventId")]
        public long EventId { get; set; }

        [DataMember(Name = "email")]

       [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Phone Number.")]
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
