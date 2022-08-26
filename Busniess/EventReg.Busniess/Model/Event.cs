using EventReg.Common.Contracts;
using System;
using System.Collections.Generic;

namespace EventReg.Busniess.Model
{
    public abstract class Event: IEvent
    {
       
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public IEnumerable<IRegistration> Registrations { get; }
    }
}
