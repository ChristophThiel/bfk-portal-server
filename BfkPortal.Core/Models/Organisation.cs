using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Core.Models
{
    public class Organisation : EntityObject
    {
        [Required]
        public string Name { get; set; }
        
        public bool IsDeleted { get; set; }

        public ICollection<Membership> Memberships { get; set; }

        public ICollection<Participation> Participations { get; set; }

        public Organisation()
        {
            Memberships = new Collection<Membership>();
            Participations = new Collection<Participation>();
        }
    }
}