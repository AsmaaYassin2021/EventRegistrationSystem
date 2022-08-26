using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventReg.Common.Contracts
{
  public  interface IEvent
    {
         long Id { get; set; }
         string Name { get; set; }
        string Description { get; set; }
        DateTime StartDateTime { get; set; }
         DateTime EndDateTime { get; set; }
 
        IEnumerable<IRegistration> Registrations { get; }


    }
}
