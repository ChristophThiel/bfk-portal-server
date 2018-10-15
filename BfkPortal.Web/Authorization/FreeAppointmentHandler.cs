using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using BfkPortal.Web.Authorization.Requirements;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using BfkPortal.Persistence.Contracts;

namespace BfkPortal.Web.Authorization
{
    public class FreeAppointmentHandler : AuthorizationHandler<FreeAppointmentRequirement>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FreeAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FreeAppointmentRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext mvcContext)
            {
                int appointmentId;
                if (mvcContext.RouteData.Values.TryGetValue(Constants.AppointmentId, out var id))
                    appointmentId = Convert.ToInt32(id);
                else
                    return Task.CompletedTask;

                var appointmnet = _unitOfWork.Appointments.FindAsync(appointmentId).Result;
                if (!appointmnet.OwnerId.HasValue)
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
