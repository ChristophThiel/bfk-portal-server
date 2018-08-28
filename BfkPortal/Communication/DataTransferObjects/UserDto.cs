using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<string> Roles { get; set; }

        public ICollection<OrganisationDto> Organisations { get; set; }
    }
}
