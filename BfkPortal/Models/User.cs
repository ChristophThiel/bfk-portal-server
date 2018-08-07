using System.Collections.Generic;

namespace BfkPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
        
        public ICollection<UserRole> Roles { get; set; }
    }
}
