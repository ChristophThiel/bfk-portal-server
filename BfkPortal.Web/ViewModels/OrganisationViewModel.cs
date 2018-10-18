using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class OrganisationViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        
        public bool? IsDeleted { get; set; }
        
        public IEnumerable<int> Memberships { get; set; }
    }
}
