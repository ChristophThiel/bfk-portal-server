using System.Collections.Generic;
using BfkPortal.Models;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string From { get; set; }
        
        public string To { get; set; }
        
        public string Type { get; set; }

        public bool AreParticipantsOrganisations { get; set; }
        
        public int MaxParticipants { get; set; }
        
        public bool ShowParticipants { get; set; }

        public string Deadline { get; set; }

        public bool IsVisible { get; set; }

        public ICollection<object> Participants { get; set; }

        public UserDto Owner { get; set; }

        public AppointmentDto() { }

        public AppointmentDto(Appointment a)
        {
            this.Id = a.Id;
            this.Title = a.Title;
            this.Description = a.Description;
            this.From = a.From.ToString("O");
            this.To = a.To.ToString("O");
            this.Type = a.Type.ToString();
            this.AreParticipantsOrganisations = a.AreParticipantsOrganisations;
            this.MaxParticipants = a.MaxParticipants;
            this.ShowParticipants = a.ShowParticipants;
            this.Deadline = a.Deadline?.ToString("O");
            this.IsVisible = a.IsVisible;
            this.Participants = new List<object>();
            if (a.AreParticipantsOrganisations)
            {
                foreach (var ao in a.OrganisationParticipants)
                    this.Participants.Add(new OrganisationDto(ao.Organisation));
            }
            else
            {
                foreach (var au in a.UserParticipants)
                    this.Participants.Add(new UserDto(au.User));
            }
            this.Owner = new UserDto(a.Owner);
        }
    }
}
