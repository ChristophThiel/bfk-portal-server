using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<UserOrganisation> Members { get; set; }
    }
}