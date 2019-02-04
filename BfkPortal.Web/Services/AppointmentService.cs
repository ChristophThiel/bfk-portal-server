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

namespace BfkPortal.Web.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidaysService _holidaysService;
        private readonly IConverter<AppointmentViewModel, Appointment> _viewModelToModelConverter;
        private readonly IConverter<Appointment, AppointmentDto> _modelToDtoConverter;

        public AppointmentService(IUnitOfWork unitOfWork,
            IHolidaysService holidaysService,
            IConverter<AppointmentViewModel, Appointment> viewModelToModelConverter,
            IConverter<Appointment,
            AppointmentDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _holidaysService = holidaysService;
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
                for (var j = 0; j  < iterations; j++)
                {
                    date = new DateTime(year, month, i, 18, 0, 0).AddHours(-6 * j);
                    var validUsers = users.Where(u => u.ShiftCount > shifts.Count(s => s.Value == u.Id))
                        .Where(u => PreferencesInvalid(u.Preferences, date));
                            //.Where(u => IsValid(u.Preferences, date));

                    var random = new Random();
                    var position = random.Next(0, validUsers.Count() - 1);
                    shifts.Add(new KeyValuePair<DateTime, int>(date, validUsers.ElementAt(position).Id));
                }
            }

            /*var userWithFixShifts = users.Where(u => u.Preferences.Any(p => !p.Avoid));

            foreach (var user in userWithFixShifts)
            {
                for (var i = 1; i <= amountOfDays; i++)
                {
                    var date = new DateTime(year, month, i, 0, 0, 0);
                    if (date.DayOfWeek == user.FixShift.Value &&
                        ((user.FixShift.Key == 1 && date.Day <= 7) || 
                        (user.FixShift.Key == 2 && date.Day <= 14) || 
                        (user.FixShift.Key == 3 && date.Day <= 21) || 
                        (user.FixShift.Key == 4 && date.Day > 21)))
                    {
                        shifts.Add(new KeyValuePair<DateTime, int>(date, user.Id));
                        break;
                    }
                }
            }

            var random = new Random();
            for (var i = 1; i <= amountOfDays; i++)
            {
                var date = new DateTime(year, month, i);
                var iterations = IsWeekend(date) || IsHoliday(date) ? 3 : 1;

                for (var j = 0; j < iterations; j++)
                {
                    date = new DateTime(year, month, i, j, 0, 0);
                    if (shifts.Any(s => s.Key == date))
                        continue;

                    var validUsers = users.Where(u => u.ShiftCount > shifts.Count(s => s.Value == u.Id))
                        .Where(u => !shifts.Any(s => s.Value == u.Id && s.Key <= date.AddDays(-7)))
                        .Where(u => u.FixShift.Key == 0)
                        .ToArray();
                    var currentUser = validUsers[random.Next(0, validUsers.Length)];

                    var shiftValidForUser = true;
                    if (currentUser.AvoidHolidays.HasValue && IsHoliday(date))
                        shiftValidForUser = false;
                    else if (currentUser.AvoidFirstDays.Count != 0)
                    {
                        foreach (var avoid in currentUser.AvoidFirstDays)
                        {
                            if (date.DayOfWeek == avoid.Value &&
                                ((avoid.Key == 1 && date.Day <= 7) || (avoid.Key == 2 && date.Day <= 14) || (avoid.Key == 3 && date.Day <= 21) || (avoid.Key == 4 && date.Day > 21)))
                                shiftValidForUser = false;
                        }
                    }
                    else if (currentUser.AvoidShiftTypes.Count != 0)
                    {
                        foreach (var avoid in currentUser.AvoidShiftTypes)
                        {
                            if (avoid == 0 && avoid == 1 && (IsWeekend(date) || IsHoliday(date)))
                                shiftValidForUser = false;
                            else if (avoid == 2 && (!IsWeekend(date) || !IsHoliday(date)))
                                shiftValidForUser = false;
                        }
                    }
                    else if (currentUser.AvoidDays.Count != 0)
                    {
                        foreach (var avoid in currentUser.AvoidDays)
                        {
                            if (date.DayOfWeek == avoid)
                                shiftValidForUser = false;
                        }
                    }
                    else if (currentUser.AvoidMonths.Count != 0)
                    {
                        foreach (var avoid in currentUser.AvoidMonths)
                        {
                            if (date.Month == avoid)
                                shiftValidForUser = false;
                        }
                    }

                    if (shiftValidForUser)
                        shifts.Add(new KeyValuePair<DateTime, int>(date, currentUser.Id));
                    else
                        i--;
                }
            }*/

            return shifts;
        }

        public async Task<AppointmentDto> Find(int id)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(id, nameof(Appointment.Participations), nameof(Appointment.Owner));
            return await _modelToDtoConverter.Convert(appointment);
        }

        public async Task OfferDuty(int appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId);
            appointment.Type = AppointmentTypes.MarktplatzDienst;
            _unitOfWork.Appointments.Update(appointment);

            await _unitOfWork.SaveChangesAsync();
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
                // (user.FixShift.Key == 1 && date.Day <= 7)

                if (IsHoliday(date) && preference.Type == PreferenceType.Holiday)
                    return preference.Avoid;

                if (IsWeekend(date) && preference.Type == PreferenceType.Weekend)
                    return preference.Avoid;

                var type = preference.Type.ToString("G");

                foreach (var month in months)
                {

                }

                foreach (var day in days)
                {
                    if (type.StartsWith(day))
                    {
                        if (int.TryParse(type.Last().ToString(), out var count))
                        {
                            if (count != 4 && culture.DateTimeFormat.GetDayName(date.DayOfWeek) == day && date.Day <= 7 * count)
                                return preference.Avoid;
                            else if (count == 4 && culture.DateTimeFormat.GetDayName(date.DayOfWeek) == day && date.Day > 21)
                                return preference.Avoid;
                        }
                        break;
                    }
                }

                /*if (preference.Avoid)
                {
                    if (type.EndsWith("1") && date.Day <= 7 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return false;
                    else if (type.EndsWith("2") && date.Day <= 14 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return false;
                    else if (type.EndsWith("3") && date.Day <= 21 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return false;
                    else if (type.EndsWith("4") && date.Day > 21 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return false;
                }
                else
                {
                    if (type.EndsWith("1") && date.Day <= 7 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return true;
                    else if (type.EndsWith("2") && date.Day <= 14 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return true;
                    else if (type.EndsWith("3") && date.Day <= 21 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return true;
                    else if (type.EndsWith("4") && date.Day > 21 &&
                        type.StartsWith(culture.DateTimeFormat.GetDayName(date.DayOfWeek)))
                        return true;
                }*/
            }
            return true;
        }
    }
}
