using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Core.Models
{
    public class User : EntityObject
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }
        
        [Required]
        public bool IsDeleted { get; set; }
        
        public string NotificationToken { get; set; }

        public ICollection<Membership> Memberships { get; set; }

        public ICollection<Participation> Participations { get; set; }

        public ICollection<Entitlement> Entitlements { get; set; }

        public ICollection<Possession> Possessions { get; set; }

        public User()
        {
            Memberships = new Collection<Membership>();
            Participations = new Collection<Participation>();
            Entitlements = new Collection<Entitlement>();
            Possessions = new Collection<Possession>();
        }
    }
}
