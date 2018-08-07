using System.ComponentModel.DataAnnotations;

namespace BfkPortal.DataTransferObjects
{
    public class CredentialsDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
