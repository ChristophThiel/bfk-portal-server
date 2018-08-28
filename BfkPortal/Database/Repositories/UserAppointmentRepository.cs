using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class UserAppointmentRepository : DefaultRepository, IUserAppointmentRepository
    {
        public UserAppointmentRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task Add(UserAppointment userAppointment) => 
            await Context.UserAppointments.AddAsync(userAppointment);
    }
}
