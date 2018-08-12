using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IAppointmentRepository
    {
        Task Add(Appointment appointment);

        Task<IEnumerable<AppointmentDto>> All(int userId);
    }
}
