using System;

namespace BfkPortal.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public User Owner { get; set; }
    }
}
