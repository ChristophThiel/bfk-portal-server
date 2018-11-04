using System;
using System.Linq;
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
                var connectionString =
                    "postgres://dmwnwtiayodukp:f311d2f70381eb9f05ed2b075422d6779fcedf3277c5c62870a5277d4b0afbe9@ec2-54-247-86-89.eu-west-1.compute.amazonaws.com:5432/da5r783auf9l6i"; //Environment.GetEnvironmentVariable("DATABASE_URL") ?? configuration.GetConnectionString("Sqlite");
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
                    return;
                }
            }
            optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));

            /*switch (configuration["Provider"])
            {
                case "MariaDb":
                    optionsBuilder.UseMySql(configuration.GetConnectionString(configuration["Provider"]));
                    break;
                case "PostgreSql":
                    var postgreSql = configuration.GetConnectionString("PostgreSql"); // Environment.GetEnvironmentVariable("DATABASE_URL");
                    if (postgreSql == null)
                        optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
                    else
                    {
                        if (!Uri.TryCreate(postgreSql, UriKind.Absolute, out var url))
                            optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
                        else
                            optionsBuilder.UseNpgsql($"Server={url.Host};Port={url.Port};User Id={url.UserInfo.Split(':')[0]};Password={url.UserInfo.Split(':')[1]};Database={url.LocalPath.Substring(1)};SSLMode=Require;TrustServerCertificate=True");
                    }
                    break;
                default:
                    optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
                    break;
            }*/
        }
    }
}
