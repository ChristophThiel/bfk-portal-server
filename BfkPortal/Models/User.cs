using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<UserRole> Roles { get; set; }

        public ICollection<AppointmentUser> Appointments { get; set; }

        public ICollection<UserOrganisation> Organisations { get; set; }
    }
}
