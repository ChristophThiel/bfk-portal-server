using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class ParticipationViewModel
    {
        [Required]
        public int? AppointmentId { get; set; }

        [Required]
        public int? ParticipantId { get; set; }
    }
}
