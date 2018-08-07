using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
