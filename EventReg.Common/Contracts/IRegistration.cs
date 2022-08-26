using System;
using System.Collections.Generic;
using System.Text;

namespace EventReg.Common.Contracts
{
    public interface IRegistration
    {
         long Id { get; set; }
       
         string Email { get; set; }
         string PhoneNumber { get; set; }
         string TicketNumber { get; set; }
         long EventId { get; set; }
          IEvent CreatedEevnt { get; }
    }
}
