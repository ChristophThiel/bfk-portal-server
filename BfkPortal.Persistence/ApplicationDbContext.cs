﻿using System;
using System.IO;
using BfkPortal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Core.Models.File> Files { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Participation> Participations { get; set; }

        public DbSet<Entitlement> Entitlements { get; set; }

        public DbSet<Possession> Possessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var source = Path.Combine(Environment.CurrentDirectory, "bfkportal.db");
            optionsBuilder.UseSqlite($"Data Source={source}");
        }
    }
}
