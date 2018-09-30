using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class ParticipateViewModel
    {
        [Required]
        public int? AppointmentId { get; set; }

        [Required]
        public int? ParticipantId { get; set; }
    }
}
