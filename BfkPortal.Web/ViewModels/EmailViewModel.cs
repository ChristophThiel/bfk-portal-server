using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Web.ViewModels
{
    public class EmailViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
