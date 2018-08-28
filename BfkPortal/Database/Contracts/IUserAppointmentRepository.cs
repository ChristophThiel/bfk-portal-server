using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IUserAppointmentRepository
    {
        Task Add(UserAppointment userAppointment);
    }
}
