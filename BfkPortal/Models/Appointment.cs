using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.Models.Enums;

namespace BfkPortal.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        [Required]
        public AppointmentTypes Type { get; set; }

        [Required]
        public bool AreParticipantsOrganisations { get; set; }

        [Required]
        public int MaxParticipants { get; set; }

        [Required]
        public bool ShowParticipants { get; set; }
        
        public DateTime? Deadline { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        public User Owner { get; set; }

        public ICollection<UserAppointment> Participants { get; set; }
    }
}
