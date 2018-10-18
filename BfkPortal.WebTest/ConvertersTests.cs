using BfkPortal.Persistence;
using BfkPortal.Web.Services.Converters;
using BfkPortal.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BfkPortal.WebTest
{
    public class ConvertersTests
    {
        [Fact]
        public void Convert_Appoinment_Converted()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var converter = new AppointmentViewModelToAppointmentConverter(unitOfWork);
                var appointmentViewModel = new AppointmentViewModel
                {
                    Title = "Nachtdienst",
                    Description = null,
                    From = DateTime.Now,
                    To = DateTime.Now.AddDays(1),
                    Type = Core.Models.Enums.AppointmentTypes.Dienst,
                    Owner = 1
                };
                var appointment = converter.Convert(appointmentViewModel).Result;
                Assert.Equal("Nachtdienst", appointment.Title);
                Assert.Equal("christoph.thiel@liwest.at", appointment.Owner.Email);

                appointmentViewModel = new AppointmentViewModel
                {
                    Title = "Vollversammlung",
                    Description = "Hello, World!",
                    From = DateTime.Now,
                    To = DateTime.Now.AddDays(1),
                    Type = Core.Models.Enums.AppointmentTypes.Dienst,
                    AreParticipantsOrganisations = true,
                    MaxParticipants = 10,
                    ShowParticipants = true,
                    Deadline = DateTime.Now,
                    IsVisible = false,
                    Owner = 1,
                    Participations = new [] { 2, 3, 4 }
                };
                appointment = converter.Convert(appointmentViewModel).Result;
                Assert.Equal("Vollversammlung", appointment.Title);
                Assert.Equal(3, appointment.Participations.Count());
            }
        }
    }
}
