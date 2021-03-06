﻿namespace BfkPortal.Core.Models
{
    public class Membership : EntityObject
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; }
    }
}
