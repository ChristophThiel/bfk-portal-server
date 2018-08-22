﻿namespace BfkPortal.Models
{
    public class UserOrganisation
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; }
    }
}