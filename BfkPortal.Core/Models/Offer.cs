using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Core.Models
{
    public class Offer : EntityObject
    {
        [Required]
        public OfferStatus Status { get; set; }

        public Appointment SenderAppointment { get; set; }

        public Appointment ReceiverAppointment { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }
    }
}
