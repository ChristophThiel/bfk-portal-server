﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
