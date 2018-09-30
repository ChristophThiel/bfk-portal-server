using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class AppointmentToMarketplaceViewModel
    {
        [Required]
        public int? AppointmentId { get; set; }

        [Required]
        public int? OwnerId { get; set; }
    }
}
