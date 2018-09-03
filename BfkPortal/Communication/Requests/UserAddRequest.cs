using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.Requests
{
    public class UserAddRequest
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public IEnumerable<string> Roles { get; set; }

        [Required]
        public IEnumerable<string> Organisations { get; set; }
    }
}
