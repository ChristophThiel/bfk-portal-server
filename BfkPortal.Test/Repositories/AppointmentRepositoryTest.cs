using BfkPortal.Database.Contracts;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace BfkPortal.Test.Repositories
{
    public class AppointmentRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AppointmentRepositoryTest(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public void FindAppointmentById_ShouldReturnAppointment()
        {
            var a = _unitOfWork.Appointments.Find(1).Result;
            Assert.NotNull(a);
            Assert.Equal("Example appointment", a.Title);
        }
    }
}
