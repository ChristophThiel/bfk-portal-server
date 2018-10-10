using System;
using System.Collections.Generic;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
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

                /*foreach (var role in Enum.GetNames(typeof(Roles)))
                {
                    unitOfWork.Roles.Add(new Role
                    {
                        Name = role,
                        Users = new List<Entitlement>()
                    });
                }
                unitOfWork.SaveChangesAsync().Wait();

                var organisations = new[]
                {
                    new Organisation
                    {
                        Name = "FF Marchtrenk",
                        IsDeleted = false,
                        Memberships = new List<Membership>()
                    },
                    new Organisation
                    {
                        Name = "BWST Wels-Land",
                        IsDeleted = false,
                        Memberships = new List<Membership>()
                    },
                    new Organisation
                    {
                        Name = "FF Pucking",
                        IsDeleted = true,
                        Memberships = new List<Membership>()
                    }
                };
                unitOfWork.Organisations.AddRange(organisations);
                unitOfWork.SaveChangesAsync().Wait();

                Console.WriteLine("Erstellen der Testdatensätze ...");
                var users = new[]
                {

                    new User
                    {
                        Firstname = "Christoph",
                        Lastname = "Thiel",
                        Email = "christoph.thiel@gmail.com",
                        Password = "Q9OLYlWYG/05TOjyXEVAnTz/OxQAz1DtdSeZ1TOJbUA=",
                        Salt = "S109YDvCSe0EGr4MGdEYGA==",
                        IsDeleted = false,
                        Entitlements = new List<Entitlement>(),
                        Memberships = new List<Membership>(),
                        Participations = new List<Participation>()
                    },
                    new User
                    {
                        Firstname = "Matthias",
                        Lastname = "Herzog",
                        Email = "matthias.herzog@gmail.com",
                        Password = "VYYKp5JPGt5wwvWrOAlfLvpA+tCEOgPriH8X6a9TweE=",
                        Salt = "0sA4lSggIbTRhnG8IIQDZw==",
                        IsDeleted = false,
                        Entitlements = new List<Entitlement>(),
                        Memberships = new List<Membership>(),
                        Participations = new List<Participation>()
                    },
                    new User
                    {
                        Firstname = "Alexander",
                        Lastname = "Koblmüller",
                        Email = "alexander.koblmüller@gmail.com",
                        Password = "L+TlwZBG1H9aZ/+gSfc+HJ6mz38omub0aUEYEY9eBf4=",
                        Salt = "CQrTIcBvejQIA8e34lOsBg==",
                        IsDeleted = false,
                        Entitlements = new List<Entitlement>(),
                        Memberships = new List<Membership>(),
                        Participations = new List<Participation>()
                    },
                    new User
                    {
                        Firstname = "Christoph",
                        Lastname = "Zimprich",
                        Email = "christoph.zimprich@gmail.com",
                        Password = "DjnFCC2p4c886sH4aPREy1FbBg+ItSmvuHI+5ZQkrLs=",
                        Salt = "K4tcRbMbEKek8s31rgbP8g==",
                        IsDeleted = false,
                        Entitlements = new List<Entitlement>(),
                        Memberships = new List<Membership>(),
                        Participations = new List<Participation>()
                    }
                };
                unitOfWork.Users.AddRange(users);
                unitOfWork.SaveChangesAsync().Wait();

                users[0].Entitlements.Add(new Entitlement
                {
                    User = users[0],
                    Role = unitOfWork.Roles.FindAsync(1).Result
                });
                users[1].Entitlements.Add(new Entitlement
                {
                    User = users[1],
                    Role = unitOfWork.Roles.FindAsync(2).Result
                });
                users[1].Entitlements.Add(new Entitlement
                {
                    User = users[1],
                    Role = unitOfWork.Roles.FindAsync(3).Result
                });
                users[2].Entitlements.Add(new Entitlement
                {
                    User = users[2],
                    Role = unitOfWork.Roles.FindAsync(3).Result
                });
                users[3].Entitlements.Add(new Entitlement
                {
                    User = users[3],
                    Role = unitOfWork.Roles.FindAsync(2).Result
                });
                users[3].Entitlements.Add(new Entitlement
                {
                    User = users[3],
                    Role = unitOfWork.Roles.FindAsync(5).Result
                });
                unitOfWork.SaveChangesAsync().Wait();

                users[0].Memberships.Add(new Membership
                {
                    User = users[0],
                    Organisation = organisations[0]
                });
                users[1].Memberships.Add(new Membership
                {
                    User = users[1],
                    Organisation = organisations[2]
                });
                users[1].Memberships.Add(new Membership
                {
                    User = users[1],
                    Organisation = organisations[1]
                });
                users[2].Memberships.Add(new Membership
                {
                    User = users[2],
                    Organisation = organisations[1]
                });
                users[3].Memberships.Add(new Membership
                {
                    User = users[3],
                    Organisation = organisations[0]
                });
                users[3].Memberships.Add(new Membership
                {
                    User = users[3],
                    Organisation = organisations[1]
                });
                unitOfWork.SaveChangesAsync().Wait();

                var appointments = new[]
                    {
                    new Appointment
                    {
                        Title = "Nachtdienst",
                        Description = "",
                        From = new DateTime(2018, 10, 26, 18, 0, 0),
                        To = new DateTime(2018, 10, 27, 6, 0, 0),
                        Type = AppointmentTypes.Dienst,
                        AreParticipantsOrganisations = false,
                        MaxParticipants = 0,
                        ShowParticipants = false,
                        Deadline = null,
                        IsVisible = true,
                        Owner = unitOfWork.Users.FindAsync(3).Result,
                        Participations = new List<Participation>()
                    },
                    new Appointment
                    {
                        Title = "Freier Dienst",
                        Description = "Weihnachten",
                        From = new DateTime(2018, 12, 24, 6, 0, 0),
                        To = new DateTime(2018, 12, 24, 18, 0, 0),
                        Type = AppointmentTypes.FreierDienst,
                        AreParticipantsOrganisations = false,
                        MaxParticipants = 0,
                        ShowParticipants = false,
                        Deadline = null,
                        IsVisible = true,
                        Owner = null,
                        Participations = new List<Participation>()
                    },
                    new Appointment
                    {
                        Title = "Vollversammlung",
                        Description = "Vollversammlung der Feuerwehr Marchtrenk",
                        From = new DateTime(2019, 3, 25, 17, 0, 0),
                        To = new DateTime(2019, 3, 25, 21, 0, 0),
                        Type = AppointmentTypes.Vollversammlung,
                        AreParticipantsOrganisations = true,
                        MaxParticipants = 10,
                        ShowParticipants = true,
                        Deadline = new DateTime(2019, 1, 1, 23, 59, 59),
                        IsVisible = true,
                        Owner = unitOfWork.Users.FindAsync(1).Result,
                        Participations = new List<Participation>()
                    },
                    new Appointment
                    {
                        Title = "Lehrgang",
                        Description = "Funklehrgang",
                        From = new DateTime(2018, 11, 12, 7, 0, 0),
                        To = new DateTime(2018, 11, 17, 16, 0, 0),
                        Type = AppointmentTypes.Lehrgang,
                        AreParticipantsOrganisations = false,
                        MaxParticipants = 50,
                        ShowParticipants = false,
                        Deadline = new DateTime(2018, 11, 1, 23, 0, 0),
                        IsVisible = true,
                        Owner = unitOfWork.Users.FindAsync(2).Result,
                        Participations = new List<Participation>()
                    },
                    new Appointment
                    {
                        Title = "Nachtdienst",
                        Description = "",
                        From = new DateTime(2018, 10, 27, 18, 0, 0),
                        To =  new DateTime(2018, 10, 28, 6, 0, 0),
                        Type = AppointmentTypes.Dienst,
                        AreParticipantsOrganisations = false,
                        MaxParticipants = 0,
                        ShowParticipants = false,
                        Deadline = null,
                        IsVisible = true,
                        Owner = unitOfWork.Users.FindAsync(4).Result,
                        Participations = new List<Participation>()
                    },
                };
                unitOfWork.Appointments.AddRange(appointments);
                unitOfWork.SaveChangesAsync().Wait();

                appointments[2].Participations.Add(new Participation
                {
                    Appointment = appointments[0],
                    Organisation = organisations[2]
                });
                appointments[3].Participations.Add(new Participation
                {
                    Appointment = appointments[3],
                    User = users[0]
                });
                appointments[3].Participations.Add(new Participation
                {
                    Appointment = appointments[3],
                    User = users[3]
                });
                unitOfWork.SaveChangesAsync().Wait();

                var offers = new[]
                {
                    new Offer
                    {
                        Sender = users[3],
                        Receiver = users[2],
                        SenderAppointment = appointments[4],
                        ReceiverAppointment = appointments[0]
                    }
                };
                unitOfWork.Offers.AddRange(offers);
                unitOfWork.SaveChangesAsync().Wait();*/
            }
        }
    }
}
