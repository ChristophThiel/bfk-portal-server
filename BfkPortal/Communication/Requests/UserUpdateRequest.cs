using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.Requests
{
    public class UserUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public IEnumerable<int> Roles { get; set; }

        [Required]
        public IEnumerable<int> Organisations { get; set; }
    }
}
