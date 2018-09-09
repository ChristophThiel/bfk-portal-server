using System.ComponentModel.DataAnnotations;
using BfkPortal.Models.Enums;

namespace BfkPortal.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required]
        public OfferStatus Status { get; set; }

        public Appointment SenderAppointment { get; set; }

        public Appointment ReceiverAppointment { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }
    }
}
