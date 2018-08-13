using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class ShiftRepository : DefaultRepository, IShiftRepository
    {
        public ShiftRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task Add(Shift shift) => await Context.Shifts.AddAsync(shift);

        public async Task Delete(int id) => Context.Shifts.Remove(await Context.Shifts.FindAsync(id));

        public async Task Update(ShiftDto shift)
        {
            await Task.Factory.StartNew(() =>
            {
                var update = new Shift
                {
                    Id = shift.Id,
                    Title = shift.Title,
                    From = DateTime.Parse(shift.From, null, DateTimeStyles.RoundtripKind),
                    To = DateTime.Parse(shift.To, null, DateTimeStyles.RoundtripKind)
                };
                Context.Shifts.Update(update);
            });
        }

        public async Task<IEnumerable<ShiftDto>> All()
        {
            return await Task<IEnumerable<ShiftDto>>.Factory.StartNew(() => Context.Shifts.Include(s => s.User)
                .Select(s => new ShiftDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    From = s.From.ToString("O"),
                    To = s.To.ToString("O"),
                    User = new UserDto
                    {
                        Id = s.User.Id,
                        Email = s.User.Email,
                        Roles = s.User.Roles.Select(ur => ur.Role.Name).ToList()
                    }
                }));
        }

        public async Task<IEnumerable<ShiftDto>> All(int userId)
        {
            var user = await Context.Users.Include(u => u.Roles).FirstAsync(u => u.Id == userId);

            return await Task<IEnumerable<ShiftDto>>.Factory.StartNew(() => Context.Shifts.Include(s => s.User).Select(s => new ShiftDto
            {
                Id = s.Id,
                Title = s.Title,
                From = s.From.ToString("O"),
                To = s.To.ToString("O"),
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = user.Roles.Select(ur => ur.Role.Name).ToList()
                }
            }));
        }
    }
}
