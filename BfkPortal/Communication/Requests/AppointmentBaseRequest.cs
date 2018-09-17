﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BfkPortal.ValidationAttributes;

namespace BfkPortal.Communication.Requests
{
    public class AppointmentBaseRequest
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, Iso8601]
        public string From { get; set; }

        [Required, Iso8601]
        public string To { get; set; }

        [Required]
        public bool AreParticipantsOrganisations { get; set; }

        [Required]
        public int MaxParticipants { get; set; }

        [Required]
        public bool ShowParticipants { get; set; }

        [NullableIso8601]
        public string Deadline { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        [Required]
        public IEnumerable<int> Participants { get; set; }

        public int Owner { get; set; }
    }
}
