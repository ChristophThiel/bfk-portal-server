using System;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;

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

        public AppointmentDto(Appointment a)
        {
            Id = a.Id;
            Title = a.Title;
            Description = a.Description;
            From = a.From;
            To = a.To;
            Type = a.Type.ToString();
            AreParticipantsOrganisations = a.AreParticipantsOrganisations;
            MaxParticipants = a.MaxParticipants;
            ShowParticipants = a.ShowParticipants;
            Deadline = a.Deadline;
            IsVisible = a.IsVisible;
        }
    }
}
