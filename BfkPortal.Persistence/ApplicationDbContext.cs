using System;
using System.IO;
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
            var source = Path.Combine(Environment.CurrentDirectory, "bfkportal.db");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            
            switch (configuration["Provider"])
            {
                case "MariaDb":
                    optionsBuilder.UseMySql(configuration.GetConnectionString(configuration["Provider"]));
                    break;
                case "PostgreSql":
                    var postgreSql = Environment.GetEnvironmentVariable("DATABASE_URL");
                    if (postgreSql == null)
                        optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
                    else
                    {
                        if (!Uri.TryCreate(postgreSql, UriKind.Absolute, out var url))
                            optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
                        else
                            optionsBuilder.UseNpgsql($"Server={url.Host};Port={url.Port};User Id={url.UserInfo.Split(':')[0]};Password={url.UserInfo.Split(':')[1]};Database={url.LocalPath.Substring(1)}");
                    }
                    break;
                default:
                    optionsBuilder.UseSqlite(configuration.GetConnectionString(configuration["Sqlite"]));
                    break;
            }
        }
    }
}
