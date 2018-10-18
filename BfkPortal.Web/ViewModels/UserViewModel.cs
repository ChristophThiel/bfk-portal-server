using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        public bool? IsDeleted { get; set; }
        
        public IEnumerable<string> Entitlements { get; set; }
        
        public IEnumerable<int> Memberships { get; set; }
    }
}
