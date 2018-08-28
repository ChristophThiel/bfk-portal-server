using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class CredentialsDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
