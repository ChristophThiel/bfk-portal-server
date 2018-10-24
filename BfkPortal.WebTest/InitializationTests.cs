using System;
using BfkPortal.Web.Services;
using BfkPortal.Persistence;
using BfkPortal.Web.Services.Converters;
using Xunit;
using BfkPortal.Web.Controllers;
using BfkPortal.Web.ViewModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using BfkPortal.Core.Models;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;

namespace BfkPortal.WebTest
{
    public class InitializationTests
    {
        public readonly string Current = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

        [Fact]
        public void Initialize()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.DeleteDatabaseAsync().Wait();
                unitOfWork.CreateDatabaseAsync().Wait();
            }

            InitializeRoles();
            InitializeOrganisations();
            InitializeUsers();
            InitializeAppointments();
            InitializeOffers();
        }

        #region Initialize data

        private void InitializeRoles()
        {
            var roleJson = System.IO.File.ReadAllText(Path.Combine(Current, "Data", "roles.json"));
            var roles = JsonConvert.DeserializeObject<IEnumerable<Role>>(roleJson);

            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Roles.AddRange(roles);
                unitOfWork.SaveChangesAsync().Wait();
                Assert.Equal(5, unitOfWork.Roles.All().Count());
            }
        }
        
        private void InitializeOrganisations()
        {
            var organisationJson = System.IO.File.ReadAllText(Path.Combine(Current, "Data", "organisations.json"));
            var organisations = JsonConvert.DeserializeObject<IEnumerable<OrganisationViewModel>>(organisationJson);

            var controller = CreateOrganisationController();
            foreach (var organisation in organisations)
            {
                var result = controller.Add(organisation).Result;
                Assert.IsType<OkObjectResult>(result);
            }

            using (var unitOfWork = new UnitOfWork())
            {
                Assert.Equal(6, unitOfWork.Organisations.All().Count());
            }
        }
        
        private void InitializeUsers()
        {
            var userJson = System.IO.File.ReadAllText(Path.Combine(Current, "Data", "users.json"));
            var users = JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(userJson);

            var controller = CreateAuthenticationController();
            for (var i = 0; i < users.Count(); i++)
            {
                var user = users.ElementAt(i);
                var result = controller.Register(user).Result;
                Assert.IsType<OkResult>(result);
            }

            using (var unitOfWork = new UnitOfWork())
            {
                Assert.Equal(9, unitOfWork.Users.All().Count());
            }
        }
        
        private void InitializeAppointments()
        {
            var appointmentJson = System.IO.File.ReadAllText(Path.Combine(Current, "Data", "appointments.json"));
            var appointments = JsonConvert.DeserializeObject<IEnumerable<AppointmentViewModel>>(appointmentJson, new IsoDateTimeConverter());

            var controller = CreateAppointmentController();
            for (var i = 0; i < appointments.Count(); i++)
            {
                var appointment = appointments.ElementAt(i);
                var result = controller.Add(appointment).Result;
                Assert.IsType<OkObjectResult>(result);
            }

            using (var unitOfWork = new UnitOfWork())
            {
                Assert.Equal(9, unitOfWork.Appointments.All().Count());
            }
        }

        private void InitializeOffers()
        {
            var offerJson = System.IO.File.ReadAllText(Path.Combine(Current, "Data", "offers.json"));
            var offers = JsonConvert.DeserializeObject<IEnumerable<OfferViewModel>>(offerJson);

            var controller = CreateOfferController();
            for (var i = 0; i < offers.Count(); i++)
            {
                var offer = offers.ElementAt(i);
                var result = controller.Add(offer).Result;
                Assert.IsType<OkObjectResult>(result);
            }
        }

        #endregion

        #region Create Controllers

        public static OrganisationController CreateOrganisationController()
        {
            var unitOfWork = new UnitOfWork();
            var service = new OrganisationService(unitOfWork,
                new OrganisationViewModelToOrganisationConverter(unitOfWork),
                new OrganisationToOrganisationDtoConverter());
            return new OrganisationController(service);
        }

        public static AuthenticationController CreateAuthenticationController()
        {
            var unitOfWork = new UnitOfWork();
            var service = new AuthenticationService(unitOfWork,
                new ConfigurationRoot(new List<IConfigurationProvider>()),
                new UserViewModelToUserConverter(unitOfWork),
                new UserToUserDtoConverter(unitOfWork, new OrganisationToOrganisationDtoConverter()));
            return new AuthenticationController(service);
        }

        public static AppointmentController CreateAppointmentController()
        {
            var unitOfWork = new UnitOfWork();
            var service = new AppointmentService(unitOfWork,
                new AppointmentViewModelToAppointmentConverter(unitOfWork),
                new AppointmentToAppointmentDtoConverter(unitOfWork,
                    new UserToUserDtoConverter(unitOfWork, new OrganisationToOrganisationDtoConverter()),
                    new OrganisationToOrganisationDtoConverter()));
            return new AppointmentController(service);
        }

        public static OfferController CreateOfferController()
        {
            var unitOfWork = new UnitOfWork();
            var service = new OfferService(unitOfWork,
                new OfferViewModelToOfferConverter(unitOfWork),
                new OfferToOfferDtoConverter(unitOfWork, new UserToUserDtoConverter(unitOfWork, 
                    new OrganisationToOrganisationDtoConverter()),
                    new AppointmentToAppointmentDtoConverter(unitOfWork, new UserToUserDtoConverter(unitOfWork, 
                        new OrganisationToOrganisationDtoConverter()), new OrganisationToOrganisationDtoConverter())));
            return new OfferController(service);
        }

        #endregion
    }
}