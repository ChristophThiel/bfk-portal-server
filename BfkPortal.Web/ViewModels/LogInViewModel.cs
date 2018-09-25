using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class LogInViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
