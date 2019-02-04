﻿namespace BfkPortal.Core.Models
{
    public class Entitlement : EntityObject
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
