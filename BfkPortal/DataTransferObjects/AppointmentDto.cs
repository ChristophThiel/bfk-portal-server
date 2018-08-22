using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.ValidationAttributes;

namespace BfkPortal.DataTransferObjects
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, Iso8601]
        public string From { get; set; }

        [Required, Iso8601]
        public string To { get; set; }

        [Required]
        public string Type { get; set; }

        public int? MaxParticipants { get; set; }

        public bool? ShowParticipants { get; set; }

        public DateTime? Deadline { get; set; }

        public bool? IsVisible { get; set; }

        public ICollection<UserDto> Participants { get; set; }

        public UserDto Owner { get; set; }
    }
}
