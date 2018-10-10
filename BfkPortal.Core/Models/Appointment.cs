using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Core.Models
{
    public class Appointment : EntityObject
    {
        [Required]
        public string Title { get; set; }
        
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }
        
        [Required]
        public DateTime? From { get; set; }
        
        [Required]
        public DateTime? To { get; set; }
        
        [Required]
        public AppointmentTypes? Type { get; set; }
        
        [Required]
        public bool? AreParticipantsOrganisations { get; set; }
        
        [Required]
        public int? MaxParticipants { get; set; }
        
        [Required]
        public bool? ShowParticipants { get; set; }
        
        public DateTime? Deadline { get; set; }
        
        [Required]
        public bool IsVisible { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }
        
        public ICollection<Participation> Participations { get; set; }
    }
}
