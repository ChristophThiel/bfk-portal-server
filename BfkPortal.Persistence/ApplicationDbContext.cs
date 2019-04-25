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

        public DbSet<Preference> Preferences { get; set; }

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

            // HEROKU
            /*var connectionString = "postgres://vjxbjytwvvcngo:e97f16afdfc862a5b1eebcb0767d578bee970b6ecaa386d775d98d9fb83e1955@ec2-79-125-6-250.eu-west-1.compute.amazonaws.com:5432/darg2shjgsm2t6"; //System.Environment.GetEnvironmentVariable("DATABASE_URL");
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
            } */
            // DROPLET
            var builder = new StringBuilder();
            builder.Append("Server=bfk-portal-postgres;Port=5432;Database=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_DATABASE"))
                .Append(";User Id=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_USER"))
                .Append(";Password=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"))
                .Append(";Pooling=true;");
            Console.WriteLine(builder.ToString());
            optionsBuilder.UseNpgsql(builder.ToString());

            // optionsBuilder.UseNpgsql("Server=bfk-portal-postgres;Port=5432;Database=bfkportal;User Id=root;Password=S6qNqxjQJLE2HzWvfojriEtD4CjLMzgU;Pooling=true;");
            // optionsBuilder.UseNpgsql("Host=192.168.99.100;Port=5432;Database=bfkportal;User Id=root;Password=root;Pooling=true;");
        }
    }
}