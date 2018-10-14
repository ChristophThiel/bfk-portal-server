using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Authorization.Requirements;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BfkPortal.Web.Authorization
{
    public class OwnerOfAppointmentHandler : AuthorizationHandler<EmptyRequirement>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerOfAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmptyRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext mvcContext)
            {
                var email = mvcContext.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                var user = _unitOfWork.Users.All(nameof(User.Entitlements))
                    .SingleOrDefault(u => u.Email == email);
                
                if (user.Entitlements.Any(e => _unitOfWork.Roles.FindAsync(e.RoleId).Result.Name.StartsWith(Constants.Admin)))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }

                var test2 = mvcContext.HttpContext.Request.Headers.Select(h => h);
                int appointmentId;
                if (mvcContext.HttpContext.Request.Method == Constants.Get)
                {
                    if (mvcContext.HttpContext.Request.Headers.TryGetValue(Constants.AppointmentId, out var id))
                        appointmentId = Convert.ToInt32(id);
                    else
                        return Task.CompletedTask;
                }
                else
                {
                    using (var reader = new StreamReader(mvcContext.HttpContext.Request.Body, Encoding.UTF8, true))
                    {
                        var json = reader.ReadToEnd();
                        try
                        {
                            var viewModel = JsonConvert.DeserializeObject<AppointmentViewModel>(json);
                            appointmentId = viewModel.Id;
                        }
                        catch
                        {
                            return Task.CompletedTask;
                        }
                    }
                }

                var appointment = _unitOfWork.Appointments.FindAsync(appointmentId).Result;
                if (appointment == null)
                    return Task.CompletedTask;

                if (appointment.OwnerId == user.Id)
                    context.Succeed(requirement);
            }
   
            return Task.CompletedTask;
        }
    }
}
