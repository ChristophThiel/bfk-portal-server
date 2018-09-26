using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IAppointmentService : IGenericService<Appointment, AppointmentViewModel, AppointmentDto>
    {
        IEnumerable<string> Types();

        Task Participate(int appointmentId, int particpantId);

        Task DutyToMarketplace(int appointmentId);
    }
}
