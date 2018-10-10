using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Core.Models
{
    public class Offer : EntityObject
    {
        [Required]
        public OfferStatus Status { get; set; }

        public int SenderAppointmentId { get; set; }

        public Appointment SenderAppointment { get; set; }

        public int ReceiverAppointmentId { get; set; }

        public Appointment ReceiverAppointment { get; set; }

        public int SenderId { get; set; }

        public User Sender { get; set; }

        public int ReceiverId { get; set; }

        public User Receiver { get; set; }
    }
}
