using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IAppointmentRepository
    {
        Task Add(Appointment appointment);

        Task<bool> Delete(int id);

        Task<bool> Update(AppointmentUpdateRequest appointment);

        Task<Appointment> Find(int id);

        Task<AppointmentType> FindType(string name);

        Task<IEnumerable<AppointmentDto>> All();

        Task<IEnumerable<string>> AllTypes();
    }
}
