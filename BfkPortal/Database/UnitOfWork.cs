using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Database.Repositories;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public IAuthenticationRepository Authentications { get; }

        public IUserRepository Users { get; }

        public IAppointmentRepository Appointments { get; }

        public IShiftRepository Shifts { get; }

        public UnitOfWork(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            Authentications = new AuthenticationRepository(context, configuration);
            Users = new UserRepository(context, configuration);
            Appointments = new AppointmentRepository(context, configuration);
            Shifts = new ShiftRepository(context, configuration);
        }

        public void Dispose() => _context.Dispose();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<bool> DeleteAsync() => await _context.Database.EnsureDeletedAsync();
    }
}
