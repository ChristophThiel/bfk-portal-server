namespace BfkPortal.Core.Models
{
    public class Entitlement : EntityObject
    {
        public User User { get; set; }

        public int UserId { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }
    }
}
