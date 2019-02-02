using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /*public async Task<ICollection> Distribute(int month)
        {
            /*var users = _unitOfWork.Users.All(nameof(User.Entitlements))
                .Where(u => u.Entitlements.Any(e => e.Role.Name == Constants.UserBwst || e.Role.Name == Constants.AdminBwst))
                .ToList();
            var users = new List<User>()
            {
                new User
                {
                    Firstname = "Christoph",
                    Lastname = "Thiel",
                    ShiftCount = 2,
                    AvoidHolidays = false
                },
                new User
                {
                    Firstname = "David",
                    Lastname = "Eilmsteiner",
                    ShiftCount = 1,
                    AvoidHolidays = true
                }
            };

            if (month >= 12 && month <= 1)
                throw new Exception(Constants.InvalidMonthExceptionMessage);

            var year = DateTime.Today.Year;
            var amountOfDays = DateTime.DaysInMonth(year, month);   
            
            // Distribute shifts
            var random = new Random();
            var index = 1;
            var filteredUsers = new List<User>();
            var shifts = new Collection<KeyValuePair<DateTime, User>>();
            while (index != amountOfDays + 1)
            {
                filteredUsers = new List<User>();
                foreach (var user in users)
                {
                    if (user.ShiftCount >= 1)
                    {
                        for (var i = 0; i < user.ShiftCount; i++)
                            filteredUsers.Add(user);
                    }
                }

                var date = new DateTime(year, month, index++);
                foreach (var user in users)
                {
                    if (IsDateWeekendOrHoliday(date) && user.AvoidHolidays.HasValue && user.AvoidHolidays.Value)
                        filteredUsers.RemoveAll(u => u == user);
                    else
                    {
                        foreach (var avoid in user.AvoidFirstDays)
                        {
                            if (date.DayOfWeek == avoid.Value &&
                                ((avoid.Key == 1 && date.Day <= 7) || (avoid.Key == 2 && date.Day <= 14) || (avoid.Key == 3 && date.Day <= 21) || (avoid.Key == 4 && date.Day > 21)))
                                filteredUsers.RemoveAll(u => u == user);
                        }
                        foreach (var avoid in user.AvoidShiftTypes)
                        {
                            if (avoid == ShiftTypes.Morning && avoid == ShiftTypes.Afternoon && IsDateWeekendOrHoliday(date))
                                filteredUsers.RemoveAll(u => u == user);
                            else if (avoid == ShiftTypes.Night && !IsDateWeekendOrHoliday(date))
                                filteredUsers.RemoveAll(u => u == user);
                        }
                        foreach (var avoid in user.AvoidDays)
                        {
                            if (date.DayOfWeek == avoid)
                                filteredUsers.RemoveAll(u => u == user);
                        }
                        foreach (var avoid in user.AvoidMonths)
                        {
                            if (date.Month == avoid)
                                filteredUsers.RemoveAll(u => u == user);
                        }
                    }
                }

                var iterations = 1;
                if (IsDateWeekendOrHoliday(date))
                    iterations = 3;
                
                for (var i = 0; i < iterations; i++)
                {
                    try
                    {
                        var number = random.Next(0, filteredUsers.Count - 1);
                        var user = filteredUsers[number];
                        while (shifts.Any(s => s.Value == user && date.AddDays(-7) != s.Key))
                        {
                            number = random.Next(0, filteredUsers.Count - 1);
                            user = filteredUsers[number];
                        }
                        shifts.Add(new KeyValuePair<DateTime, User>(date, filteredUsers[number]));
                        filteredUsers.RemoveAt(number);
                    }
                    catch
                    {
                        break;
                    }
                };
            }

            return shifts;
        }*/

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
                    ShiftCount = 1,
                    FixShift = new KeyValuePair<int, DayOfWeek>(1, DayOfWeek.Wednesday)
                },
                new User
                {
                    Id = 2,
                    Firstname = "David",
                    Lastname = "Eilmsteiner",
                    ShiftCount = 0,
                    AvoidHolidays = true
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
                    ShiftCount = 1,
                    AvoidHolidays = true
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
                    ShiftCount = 1,
                    AvoidHolidays = true
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
                    ShiftCount = 1,
                    AvoidHolidays = true
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

            var year = DateTime.Today.Year;
            var amountOfDays = DateTime.DaysInMonth(year, month);
            if (users.Sum(u => u.ShiftCount) < amountOfDays)
                throw new Exception(Constants.ImpossibleDistributionExceptionMessage);

            var shifts = new List<KeyValuePair<DateTime, int>>();
            var userWithFixShifts = users.Where(u => u.FixShift.HasValue);
            foreach (var user in userWithFixShifts)
            {
                for (var i = 1; i <= amountOfDays; i++)
                {
                    var date = new DateTime(year, month, i, 0, 0, 0);
                    if (date.DayOfWeek == user.FixShift.Value.Value &&
                        ((user.FixShift.Value.Key == 1 && date.Day <= 7) || 
                        (user.FixShift.Value.Key == 2 && date.Day <= 14) || 
                        (user.FixShift.Value.Key == 3 && date.Day <= 21) || 
                        (user.FixShift.Value.Key == 4 && date.Day > 21)))
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
                        .Where(u => !u.FixShift.HasValue)
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
                            if (avoid == ShiftTypes.Morning && avoid == ShiftTypes.Afternoon && (IsWeekend(date) || IsHoliday(date)))
                                shiftValidForUser = false;
                            else if (avoid == ShiftTypes.Night && (!IsWeekend(date) || !IsHoliday(date)))
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
            else if (appointment.Type == AppointmentTypes.Dienst ||
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
            appointment.Type = AppointmentTypes.Dienst;
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

        private bool IsHoliday(DateTime date)
        {
            return _holidaysService.All(DateTime.Today.Year)
                .Any(h => DateTime.Parse(h.Date) == date);
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
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
    }
}
