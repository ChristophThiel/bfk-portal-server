﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using BfkPortal.Communication.Requests;

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
        public AppointmentType Type { get; set; }

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