﻿using System;
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
            /* var builder = new StringBuilder();
            builder.Append("User ID=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_USER", EnvironmentVariableTarget.Machine))
                .Append(";Password=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_PASSWORD", EnvironmentVariableTarget.Machine))
                .Append(";Host=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_URL", EnvironmentVariableTarget.Machine))
                .Append(";Port=5432;Database=")
                .Append(Environment.GetEnvironmentVariable("POSTGRES_DATABASE", EnvironmentVariableTarget.Machine))
                .Append(";Pooling=true;");
            optionsBuilder.UseNpgsql(builder.ToString()); */
            optionsBuilder.UseNpgsql("User ID=root;Password=S6qNqxjQJLE2HzWvfojriEtD4CjLMzgU;Host=207.154.201.108;Port=5432;Database=bfkportal;Pooling=true;Timeout=60;", builder =>
            {
                builder.CommandTimeout(30);
                builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(10), null);
            });
        }
    }
}