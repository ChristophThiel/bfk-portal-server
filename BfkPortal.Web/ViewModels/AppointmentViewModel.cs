using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;

namespace BfkPortal.Web.ViewModels
{
    public class AppointmentViewModel : EntityViewModel
    {
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public DateTime? From { get; set; }

        [Required]
        public DateTime? To { get; set; }

        [Required]
        [EnumDataType(typeof(AppointmentTypes), ErrorMessage = "This is not a valid type!")]
        public AppointmentTypes? Type { get; set; }
        
        public bool? AreParticipantsOrganisations { get; set; }
        
        public int? MaxParticipants { get; set; }
        
        public bool? ShowParticipants { get; set; }
        
        public DateTime? Deadline { get; set; }
        
        public bool? IsVisible { get; set; }
        
        public int? Owner { get; set; }
        
        public IEnumerable<int> Participations { get; set; }
    }
}
