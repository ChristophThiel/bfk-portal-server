﻿namespace BfkPortal.Core.Models
{
    public class Participation : EntityObject
    {
        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }

        public User User { get; set; }

        public int? UserId { get; set; }

        public Organisation Organisation { get; set; }

        public int? OrganisationId { get; set; }
    }
}
