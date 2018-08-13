using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IAppointmentRepository
    {
        Task Add(Appointment appointment);

        Task Delete(int id);

        Task Update(AppointmentDto appointment);

        Task<Appointment> Find(int id);

        Task<IEnumerable<AppointmentDto>> All();

        Task<IEnumerable<AppointmentDto>> All(int userId);
    }
}
