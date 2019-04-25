using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Hosting;

namespace BfkPortal.Web.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _environment;
        private readonly IHolidaysService _holidaysService;
        private readonly IEmailService _emailService;
        private readonly IConverter<AppointmentViewModel, Appointment> _viewModelToModelConverter;
        private readonly IConverter<Appointment, AppointmentDto> _modelToDtoConverter;

        public AppointmentService(IUnitOfWork unitOfWork,
            IHostingEnvironment environment,
            IHolidaysService holidaysService,
            IEmailService emailService,
            IConverter<AppointmentViewModel, Appointment> viewModelToModelConverter,
            IConverter<Appointment,
            AppointmentDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _holidaysService = holidaysService;
            _emailService = emailService;
            _viewModelToModelConverter = viewModelToModelConverter;
            _modelToDtoConverter = modelToDtoConverter;
        }

        public async Task<int> Add(AppointmentViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Appointments.Add(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        public IEnumerable<AppointmentDto> All()
        {
            var appointments = _unitOfWork.Appointments.All(nameof(Appointment.Participations), nameof(Appointment.Owner));
            return appointments.Select(a => _modelToDtoConverter.Convert(a).Result);
        }

        public async Task<IEnumerable<KeyValuePair<DateTime, int>>> Distribute(int month)
        {
            if (month >= 12 && month <= 1)
                throw new Exception(Constants.InvalidMonthExceptionMessage);

            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Firstname = "Christoph",
                    Lastname = "Thiel",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 2,
                    Firstname = "David",
                    Lastname = "Eilmsteiner",
                    ShiftCount = 1,
                    Preferences = new Collection<Preference>
                    {
                        new Preference
                        {
                            Avoid = true,
                            Type = PreferenceType.Holiday
                        }
                    }
                },
                new User
                {
                    Id = 3,
                    Firstname = "Andreas",
                    Lastname = "Weinzierl",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 4,
                    Firstname = "Daniel",
                    Lastname = "Heureka",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 5,
                    Firstname = "Gustav",
                    Lastname = "Gans",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 6,
                    Firstname = "Helmut",
                    Lastname = "Schätz",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 7,
                    Firstname = "Wolfgang",
                    Lastname = "Ramm",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 8,
                    Firstname = "Matthias",
                    Lastname = "Buhm",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 9,
                    Firstname = "Otto",
                    Lastname = "Walkes",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 10,
                    Firstname = "Wolfgang",
                    Lastname = "Beethoven",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 11,
                    Firstname = "Imran",
                    Lastname = "Topalovic",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 12,
                    Firstname = "Xaver",
                    Lastname = "DJ",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 13,
                    Firstname = "Denzel",
                    Lastname = "Chicago",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 14,
                    Firstname = "Paula",
                    Lastname = "Pulus",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 15,
                    Firstname = "Titus",
                    Lastname = "Banana",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 16,
                    Firstname = "Emil",
                    Lastname = "Donovan",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 17,
                    Firstname = "Edward",
                    Lastname = "Thatch",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 18,
                    Firstname = "Edward",
                    Lastname = "Kenway",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 19,
                    Firstname = "Benjamin",
                    Lastname = "Hornigold",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 20,
                    Firstname = "Klaus",
                    Lastname = "Dieter",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 21,
                    Firstname = "Alexander",
                    Lastname = "Gramm",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 22,
                    Firstname = "Rudolf",
                    Lastname = "Rosenberger",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 23,
                    Firstname = "Anton",
                    Lastname = "Toni",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 24,
                    Firstname = "Konrad",
                    Lastname = "Conelius",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 25,
                    Firstname = "Niklas",
                    Lastname = "Bronze",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 26,
                    Firstname = "Siegi",
                    Lastname = "Vogel",
                    ShiftCount = 2
                },
                new User
                {
                    Id = 27,
                    Firstname = "Keine",
                    Lastname = "Ahnung",
                    ShiftCount = 1
                },
                new User
                {
                    Id = 28,
                    Firstname = "Christoph",
                    Lastname = "LastButNOtLeast",
                    ShiftCount = 0
                }
            };
            users = _unitOfWork.Users.All(nameof(User.Preferences))
                .ToList();

            //var year = month < DateTime.Today.Month ? DateTime.Today.Year + 1 : DateTime.Today.Year;
            var year = DateTime.Today.Year;
            var amountOfDays = DateTime.DaysInMonth(year, month);
            var amountOfShifts = amountOfDays + _holidaysService.All()
                .Where(h => DateTime.Parse(h.Date).Month == month)
                .Count() * 2 + CountDays(DayOfWeek.Saturday, year, month, amountOfDays) * 2 +
                CountDays(DayOfWeek.Sunday, year, month, amountOfDays) * 2;

            /* if (users.Sum(u => u.ShiftCount) < amountOfShifts)
                throw new Exception(Constants.ImpossibleDistributionExceptionMessage); */

            var shifts = new List<KeyValuePair<DateTime, int>>();
            for (var i = 1; i <= amountOfDays; i++)
            {
                var date = new DateTime(year, month, i, 18, 0, 0);
                var iterations = IsWeekend(date) || IsHoliday(date) ? 3 : 1;
                for (var j = 0; j < iterations; j++)
                {
                    date = new DateTime(year, month, i, 18, 0, 0).AddHours(-6 * j);
                    var help = users.Where(u => u.ShiftCount > shifts.Count(s => s.Value == u.Id));
                    var validUsers = users.Where(u => u.ShiftCount > shifts.Count(s => s.Value == u.Id))
                        .Where(u => !PreferencesInvalid(u.Preferences, date));

                    var random = new Random();
                    var position = random.Next(0, validUsers.Count() - 1);
                    shifts.Add(new KeyValuePair<DateTime, int>(date, validUsers.ElementAt(position).Id));
                }
            }

            return shifts;
        }

        public async Task<AppointmentDto> Find(int id)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(id, nameof(Appointment.Participations), nameof(Appointment.Owner));
            return await _modelToDtoConverter.Convert(appointment);
        }

        public async Task OfferDuty(int appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Owner));
            appointment.Type = AppointmentTypes.MarktplatzDienst;
            _unitOfWork.Appointments.Update(appointment);

            await _unitOfWork.SaveChangesAsync();

            var users = _unitOfWork.Entitlements.All(nameof(Entitlement.User), nameof(Entitlement.Role))
              .Where(e => e.Role.Name == Constants.UserBwst || e.Role.Name == Constants.AdminBwst)
              .Select(e => e.User);

            foreach (var user in users)
            {
                var content = System.IO.File.ReadAllText(System.IO.Path.Combine(_environment.ContentRootPath, Constants.WwwRoot, Constants.EmailTemplateFoldername, Constants.MarketplaceEmailFilename))
                  .Replace("@NAME@", user.Name)
                  .Replace("@APPOINTMENT_USER_NAME@", appointment.Owner.Name)
                  .Replace("@APPOINTMENT_DATE@", appointment.From.ToString("MM.dd.yyyy"));
                await _emailService.Send(user.Email, Constants.MarketplaceEmailSubject, content);
            }
        }

        public async Task Participate(int appointmentId, int particpantId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Participations));
            if (IsParticipant(appointment, particpantId))
                throw new Exception(Constants.AlreadyParticipantExceptionMessage);
            else if (appointment.Participations.Count() == appointment.MaxParticipants)
                throw new Exception(Constants.MaxPaticipantsExceptionMessage);
            else if (appointment.Deadline.HasValue && appointment.Deadline >= DateTime.Now)
                throw new Exception(Constants.ExceededDeadlineExcpetionMessage);
            else if (appointment.Type == AppointmentTypes.VormittagsDienst ||
                     appointment.Type == AppointmentTypes.NachmittagsDienst ||
                     appointment.Type == AppointmentTypes.NachtDienst ||
                     appointment.Type == AppointmentTypes.FreierDienst ||
                     appointment.Type == AppointmentTypes.MarktplatzDienst)
                throw new Exception(Constants.UnableToParticipateExceptionMessage);

            if (appointment.AreParticipantsOrganisations)
            {
                var organisation = await _unitOfWork.Organisations.FindAsync(particpantId);
                appointment.Participations.Add(new Participation
                {
                    Appointment = appointment,
                    Organisation = organisation
                });
            }
            else
            {
                var user = await _unitOfWork.Users.FindAsync(particpantId);
                appointment.Participations.Add(new Participation
                {
                    Appointment = appointment,
                    User = user
                });
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _unitOfWork.Appointments.Remove(await _unitOfWork.Appointments.FindAsync(id));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TakeDuty(int appointmentId, string email)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Owner),
                nameof(Appointment.Participations));

            var user = _unitOfWork.Users.All()
                .SingleOrDefault(u => u.Email == email);
            appointment.Owner = user;
            if (appointment.From.Hour >= 6)
                appointment.Type = AppointmentTypes.VormittagsDienst;
            else if (appointment.From.Hour >= 18)
                appointment.Type = AppointmentTypes.NachtDienst;
            else
                appointment.Type = AppointmentTypes.NachmittagsDienst;
            _unitOfWork.Appointments.Update(appointment);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Unparticipate(int appointmentId, int participantId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Participations));
            if (!IsParticipant(appointment, participantId))
                throw new Exception(Constants.AlreadyParticipantExceptionMessage);

            for (var i = 0; i < appointment.Participations.Count; i++)
            {
                var participant = appointment.Participations.ElementAt(i);
                if (participant.OrganisationId == participantId || participant.UserId == participantId)
                    appointment.Participations.Remove(participant);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(AppointmentViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Appointments.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        private int CountDays(DayOfWeek day, int year, int month, int days)
        {
            var start = new DateTime(year, month, 1);
            var end = new DateTime(year, month, days);
            var ts = end - start;
            var count = (int)Math.Floor(ts.TotalDays / 7);
            var remainder = (int)(ts.TotalDays % 7);
            var sinceLastDay = end.DayOfWeek - day;

            if (sinceLastDay < 0)
                sinceLastDay += 7;
            if (remainder >= sinceLastDay)
                count++;

            return count;
        }

        private bool IsHoliday(DateTime date)
        {
            return _holidaysService.All(DateTime.Today.Year)
                .Any(h => DateTime.Parse(h.Date).Date == date.Date);
        }

        private bool IsParticipant(Appointment appointment, int participantId)
        {
            if (appointment.Participations == null)
                appointment.Participations = new List<Participation>();
            foreach (var participant in appointment.Participations)
            {
                if (appointment.AreParticipantsOrganisations)
                {
                    if (participant.OrganisationId == participantId)
                        return true;
                }
                else
                {
                    if (participant.UserId == participantId)
                        return true;
                }
            }
            return false;
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        private bool PreferencesInvalid(IEnumerable<Preference> preferences, DateTime date)
        {
            var culture = new CultureInfo("de-DE");
            if (preferences.Count() == 0)
                return true;

            var days = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .Select(d => culture.DateTimeFormat.GetDayName(d));
            var months = new List<string>();
            for (var i = 1; i <= 12; i++)
                months.Add(new DateTime(date.Year, i, 1).ToString("MMMM"));

            foreach (var preference in preferences)
            {
                if (IsHoliday(date) && preference.Type == PreferenceType.Holiday)
                    return preference.Avoid;

                if (IsWeekend(date) && preference.Type == PreferenceType.Weekend)
                    return preference.Avoid;

                if (preference.Type == PreferenceType.VormittagDienst && date.Hour == 6)
                    return preference.Avoid;
                else if (preference.Type == PreferenceType.NachmittagDienst && date.Hour == 12)
                    return preference.Avoid;
                else if (preference.Type == PreferenceType.NachtDienst && date.Hour == 18)
                    return preference.Avoid;

                var type = preference.Type.ToString("G");

                foreach (var month in months)
                {
                    if (type == month)
                        return preference.Avoid;
                }

                foreach (var day in days)
                {
                    if (type.StartsWith(day))
                    {
                        if (!type.Any(c => char.IsDigit(c)))
                        {
                            if (culture.DateTimeFormat.GetDayName(date.DayOfWeek) == day)
                                return preference.Avoid;
                        }
                        else if (int.TryParse(type.Last().ToString(), out var count))
                        {
                            if (count != 4 && culture.DateTimeFormat.GetDayName(date.DayOfWeek) == day && date.Day <= 7 * count)
                                return preference.Avoid;
                            else if (count == 4 && culture.DateTimeFormat.GetDayName(date.DayOfWeek) == day && date.Day > 21)
                                return preference.Avoid;
                        }
                        break;
                    }
                }
            }
            return false;
        }
    }
}
