using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Core.Models
{
    public class Role : EntityObject
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Entitlement> Entitlements { get; set; }

        public Role()
        {
            Entitlements = new Collection<Entitlement>();
        }
    }
}
