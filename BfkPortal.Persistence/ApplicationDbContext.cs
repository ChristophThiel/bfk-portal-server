﻿using System;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> ff856af5104cd25be151dc5ec33a4689be8ce9d6
using BfkPortal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Entitlement> Entitlements { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Participation> Participations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            var source = Path.Combine(Environment.CurrentDirectory, "bfkportal.db");
            // TODO Change to MariaDb provider
            optionsBuilder.UseSqlite($"Data Source={source}");
=======
            optionsBuilder.UseSqlite($"Data Source={Environment.CurrentDirectory}/bfkportal.db");
>>>>>>> ff856af5104cd25be151dc5ec33a4689be8ce9d6
        }
    }
}
