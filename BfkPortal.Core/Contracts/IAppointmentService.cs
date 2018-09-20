using BfkPortal.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Core.Contracts
{
    public interface IAppointmentService
    {
        ModelStateDictionary Add(Appointment entity);
    }
}
