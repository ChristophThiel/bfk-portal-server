using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        List<string> Types();
    }
}
