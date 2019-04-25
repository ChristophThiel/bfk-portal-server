using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class UserViewModel : EntityViewModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool? IsEnabled { get; set; }

        public bool? IsDeleted { get; set; }

        public int? ShiftCount { get; set; }

        public IEnumerable<string> Entitlements { get; set; }

        public IEnumerable<int> Memberships { get; set; }

        public IEnumerable<PreferenceViewModel> Preferences { get; set; }

        public UserViewModel()
        {
            Preferences = new List<PreferenceViewModel>();
        }
    }
}
