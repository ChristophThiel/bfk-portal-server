using System;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.Core.Models
{
    public class File : EntityObject
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
