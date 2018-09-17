using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Core.Models
{
    public class Role : EntityObject
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Entitlement> Users { get; set; }
    }
}
