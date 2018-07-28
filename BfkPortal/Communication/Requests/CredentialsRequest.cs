using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.Requests
{
    public class CredentialsRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public CredentialsRequest(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
