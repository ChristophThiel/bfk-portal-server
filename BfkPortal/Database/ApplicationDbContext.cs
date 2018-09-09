using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserOrganisation> UserOrganisations { get; set; }

        public DbSet<AppointmentOrganisation> AppointmentOrganisations { get; set; }

        public DbSet<AppointmentUser> AppointmentUsers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
