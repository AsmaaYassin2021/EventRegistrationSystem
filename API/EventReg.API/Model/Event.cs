using EventReg.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EventReg.API.Model
{
    [DataContract(Name = "event")]
    internal class Event : IEvent
    {
        public Event(IEvent currentEvent)
        {
            Id = currentEvent.Id;
            Name = currentEvent.Name;
            Description = currentEvent.Description;
            StartDateTime = currentEvent.StartDateTime;
            EndDateTime = currentEvent.EndDateTime;
        }
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "eventName")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "startDateTime")]
        public DateTime StartDateTime { get; set; }
        [DataMember(Name = "endDateTime")]
        public DateTime EndDateTime { get; set; }
        [IgnoreDataMember]
        public IEnumerable<IRegistration> Registrations { get; }


    }
}
