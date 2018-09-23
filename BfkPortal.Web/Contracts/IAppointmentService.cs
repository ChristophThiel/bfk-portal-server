using System.Collections.Generic;
using BfkPortal.Core.Models;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IAppointmentService : IGenericService<Appointment, AppointmentViewModel, AppointmentDto>
    {
        IEnumerable<string> Types();
    }
}
