﻿using System.Collections.Generic;

namespace BfkPortal.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
