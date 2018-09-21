using System;
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
                    IsDeleted = false
                };
                unitOfWork.Users.Add(user);

                Console.WriteLine("Speichern ...");
                unitOfWork.SaveChangesAsync().Wait();

                var result = unitOfWork.Users.FindAsync(user.Id).Result;
                Console.WriteLine($"Id: {result.Id}, {result.Email}");
            }
        }
    }
}
