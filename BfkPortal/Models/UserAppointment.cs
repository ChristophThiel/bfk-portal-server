﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BfkPortal.Models
{
    public class UserAppointment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }
    }
}
