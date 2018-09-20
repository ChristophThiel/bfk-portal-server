using BfkPortal.Core.Contracts;
using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(ModelStateDictionary modelState)
        {
            this._modelState = modelState;
            this._unitOfWork = new UnitOfWork();
        }

        public ModelStateDictionary Add(Appointment entity)
        {
            _unitOfWork.Appointments.Add(entity);
            return _modelState;
        }
    }
}
