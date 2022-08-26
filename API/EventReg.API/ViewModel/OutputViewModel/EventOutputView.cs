using System.Runtime.Serialization;

namespace EventReg.API.ViewModel.OutputViewModel
{
    [DataContract(Name = "eventView")]
    public class EventOutputView
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "eventName")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
