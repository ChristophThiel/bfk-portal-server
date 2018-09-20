using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Core.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<Membership> Memberships { get; set; }

        public ICollection<Participation> Participations { get; set; }
    }
}