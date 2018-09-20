using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }
        
        public DateTime From { get; set; }
        
        public DateTime To { get; set; }
        
        public AppointmentTypes Type { get; set; }
        
        public bool AreParticipantsOrganisations { get; set; }
        
        public int MaxParticipants { get; set; }
        
        public bool ShowParticipants { get; set; }
        
        public DateTime? Deadline { get; set; }
        
        public bool IsVisible { get; set; }

        public User Owner { get; set; }
        
        public ICollection<Participation> Participations { get; set; }
    }
}
