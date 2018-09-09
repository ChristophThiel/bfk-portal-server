using System.ComponentModel.DataAnnotations;
using BfkPortal.Models.Enums;

namespace BfkPortal.Communication.Requests
{
    public class OfferUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required, EnumDataType(typeof(OfferStatus), ErrorMessage = "Value is not a valid status for an offer")]
        public string Status { get; set; }

        [Required]
        public int SenderAppointmentId { get; set; }

        [Required]
        public int ReceiverAppointmentId { get; set; }
    }
}
