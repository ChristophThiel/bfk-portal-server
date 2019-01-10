using System;
using System.Text;
using BfkPortal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            if (configuration["Provider"] == "PostgreSql")
            {
                var connectionString = "postgres://rzobslupbozieg:056e5060af8296e0a5ea52012d4ce29028dd72678d4fe6986bf22a25b9fbb2c5@ec2-54-247-161-208.eu-west-1.compute.amazonaws.com:5432/dfjp3cs9te534r"; //System.Environment.GetEnvironmentVariable("DATABASE_URL");
                if (Uri.TryCreate(connectionString, UriKind.Absolute, out var uri))
                {
                    var userInfos = uri.UserInfo.Split(':');
                    var builder = new StringBuilder();
                    builder.Append("Server=").Append(uri.Host)
                        .Append(";Port=").Append(uri.Port)
                        .Append(";User Id=").Append(userInfos[0])
                        .Append(";Password=").Append(userInfos[1])
                        .Append(";Database=").Append(uri.LocalPath.Substring(1))
                        .Append(";SSLMode=Require;TrustServerCertificate=True");
                    optionsBuilder.UseNpgsql(builder.ToString());
                }
            }
            else
                optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
        }
    }
}
