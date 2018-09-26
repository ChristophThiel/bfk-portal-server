using System;
using System.Collections.Generic;
using BfkPortal.Core.Models;
using BfkPortal.Persistence;

namespace BfkPortal.Import
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Console.WriteLine("Löschen der Datenbank ...");
                unitOfWork.DeleteDatabaseAsync().Wait();

                Console.WriteLine("Erstellen der Datenbank ...");
                unitOfWork.CreatDatabaseAsync().Wait();

                Console.WriteLine("Erstelle Daten ...");
                var user = new User
                {
                    Firstname = "Christoph",
                    Lastname = "Thiel",
                    Email = "christoph.thiel@liwest.at",
                    Salt = "",
                    Password = "test",
                    IsDeleted = false,
                    Entitlements = new List<Entitlement>(),
                    Memberships = new List<Membership>(),
                    Participations = new List<Participation>()
                };
                var role = new Role
                {
                    Name = "UserBfk"
                };
                var appointment = new Appointment
                {
                    Title = "Freier Dienst",
                    Description = "Weihnachten",
                    To = DateTime.Now,
                    From = DateTime.Now,
                    Type = Core.Models.Enums.AppointmentTypes.FreierDienst,
                    AreParticipantsOrganisations = false,
                    MaxParticipants = 0,
                    ShowParticipants = false,
                    Deadline = null,
                    IsVisible = true,
                    Owner = null,
                    Participations = new List<Participation>()
                };
                user.Entitlements.Add(new Entitlement
                {
                    User = user,
                    Role = role
                });
                unitOfWork.Roles.Add(role);
                unitOfWork.Users.Add(user);
                unitOfWork.Appointments.Add(appointment);

                Console.WriteLine("Speichern ...");
                unitOfWork.SaveChangesAsync().Wait();

                var result = unitOfWork.Users.FindAsync(user.Id).Result;
                Console.WriteLine($"Id: {result.Id}, {result.Email}");

                var result2 = unitOfWork.Appointments.FindAsync(appointment.Id).Result;
                Console.WriteLine($"Id: {result2.Id}, {result2.Owner}");
            }
        }
    }
}
