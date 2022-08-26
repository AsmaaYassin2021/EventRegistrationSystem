using EventReg.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventReg.Data.Model
{
    public class Registration: IRegistration
    {
        
        public Registration()
        {
          
        }


        [Key]      
        public long Id { get; set; }
        [MaxLength(254)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TicketNumber { get; set; }
        // Foreign key to customer
        [ForeignKey("EventRegisteration")]
        public long EventId { get; set; }


        [NotMapped]
        public IEvent CreatedEevnt
        {
            get
            {
                return EventRegisteration;
            }
        }
        public virtual Event EventRegisteration { get; set; }
    }
}
