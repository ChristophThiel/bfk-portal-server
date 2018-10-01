using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class OrganisationViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool? IsDeleted { get; set; }

        [Required]
        public IEnumerable<int> Memberships { get; set; }

        [Required]
        public IEnumerable<int> Participations { get; set; }
    }
}
