using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BfkPortal.DataTransferObjects
{
    public class AppointmentTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
