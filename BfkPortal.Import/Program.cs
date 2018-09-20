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
                unitOfWork.DropDatabaseAsync().Wait();

                Console.WriteLine("Erstellen der Datenbank ...");
                unitOfWork.CreatDatabaseAsync().Wait();
            }
        }
    }
}
