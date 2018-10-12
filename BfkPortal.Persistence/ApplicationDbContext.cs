using System;
using System.IO;
using BfkPortal.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Participation> Participations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var source = Path.Combine(Environment.CurrentDirectory, "bfkportal.db");
            optionsBuilder.UseSqlite($"Data Source={source}");
        }
    }
}
