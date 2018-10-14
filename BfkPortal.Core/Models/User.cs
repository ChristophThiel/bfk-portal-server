using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Core.Models
{
    public class User : EntityObject
    {
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

        public ICollection<Membership> Memberships { get; set; }

        public ICollection<Participation> Participations { get; set; }

        public ICollection<Entitlement> Entitlements { get; set; }
    }

    /* [Required]
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

    public ICollection<Entitlement> Entitlements { get; set; }

    public ICollection<Membership> Memberships { get; set; }

    public ICollection<Participation> Participations { get; set; } 
}*/
}
