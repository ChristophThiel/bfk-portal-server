using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BfkPortal.Models
{
    public class AppointmentType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
