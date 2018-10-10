using System;
using System.Collections.Generic;
using System.Linq;
using BfkPortal.Core.Models;

namespace BfkPortal.Web.ViewModels.DataTransferObjects
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Type { get; set; }

        public bool AreParticipantsOrganisations { get; set; }

        public int MaxParticipants { get; set; }

        public bool ShowParticipants { get; set; }

        public DateTime? Deadline { get; set; }

        public bool IsVisible { get; set; }

        public IEnumerable<object> Participations { get; set; }

        public UserDto Owner { get; set; }

        public AppointmentDto(Appointment a)
        {
            /* Id = a.Id;
            Title = a.Title;
            Description = a.Description;
            From = a.From.Value;
            To = a.To.Value;
            Type = a.Type.ToString();
            AreParticipantsOrganisations = a.AreParticipantsOrganisations.Value;
            MaxParticipants = a.MaxParticipants.Value;
            ShowParticipants = a.ShowParticipants.Value;
            Deadline = a.Deadline;
            IsVisible = a.IsVisible;
            if (AreParticipantsOrganisations)
                Participations = a.Participations.Select(p => new OrganisationDto(p.Organisation));
            else
                Participations = a.Participations.Select(p => new UserDto(p.User));
            if (a.Owner != null)
                Owner = new UserDto(a.Owner); */
        }
    }
}
