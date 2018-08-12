using System.ComponentModel.DataAnnotations;
using BfkPortal.ValidationAttributes;

namespace BfkPortal.DataTransferObjects
{
    public class AppointmentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, Iso8601]
        public string From { get; set; }

        [Required, Iso8601]
        public string To { get; set; }

        public UserDto Owner { get; set; }
    }
}
