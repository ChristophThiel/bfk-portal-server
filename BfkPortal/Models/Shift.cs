using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BfkPortal.Models
{
    public class Shift
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public User User { get; set; }
    }
}
