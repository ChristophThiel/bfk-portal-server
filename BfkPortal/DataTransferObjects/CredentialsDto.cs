using System.ComponentModel.DataAnnotations;

namespace BfkPortal.DataTransferObjects
{
    public class CredentialsDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public CredentialsDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
