using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BfkPortal.Models;
using BfkPortal.ValidationAttributes;

namespace BfkPortal.Communication.DataTransferObjects
{
    public class AppointmentDto
    {
        [Required]
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

        [Required]
        public int MaxParticipants { get; set; }

        [Required]
        public bool ShowParticipants { get; set; }

        public string Deadline { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        public ICollection<UserDto> Participants { get; set; }

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
            this.MaxParticipants = a.MaxParticipants;
            this.ShowParticipants = a.ShowParticipants;
            this.Deadline = a.Deadline?.ToString("O");
            this.IsVisible = a.IsVisible;
            this.Participants = a.Participants.Select(p => new UserDto(p.User)).ToList();
            this.Owner = new UserDto(a.Owner);
        }
    }
}
