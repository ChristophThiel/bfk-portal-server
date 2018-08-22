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

        Task<AppointmentType> FindType(string name);

        Task<IEnumerable<AppointmentDto>> All();

        Task<IEnumerable<string>> AllTypes();
    }
}
