using EventReg.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventReg.Data.Model
{
    public  class Event: IEvent
    {
       
        public Event()
        {
           
        }

        [Key]
        public long Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }


        [NotMapped]
        public IEnumerable<IRegistration> Registrations
        {
            get
            {
                return EventRegistrations;
            }


        }
        public virtual ICollection<Registration> EventRegistrations { get; set; }
    }
}
