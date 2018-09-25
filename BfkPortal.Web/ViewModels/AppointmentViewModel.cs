using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Web.Validations;

namespace BfkPortal.Web.ViewModels
{
    public class AppointmentViewModel : BaseViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Required, Iso8601]
        public string From { get; set; }

        [Required, Iso8601]
        public string To { get; set; }

        [Required]
        [EnumDataType(typeof(AppointmentTypes), ErrorMessage = "This is not a valid type!")]
        public AppointmentTypes? Type { get; set; }

        [Required]
        public bool? AreParticipantsOrganisations { get; set; }

        [Required]
        public int? MaxParticipants { get; set; }

        [Required]
        public bool? ShowParticipants { get; set; }

        [Required(AllowEmptyStrings = true), NullableIso8601]
        public string Deadline { get; set; }

        [Required]
        public bool? IsVisible { get; set; }
        
        public int? Owner { get; set; }

        [Required]
        public IEnumerable<int> Participations { get; set; }
    }
}
