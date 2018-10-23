using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Authorization.Requirements;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
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
    public class UserOfSameRoleGroupHandler : AuthorizationHandler<UserOfSameRoleGroupRequirement>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserOfSameRoleGroupHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOfSameRoleGroupRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext mvcContext)
            {
                mvcContext.HttpContext.Request.EnableRewind();
                var email = mvcContext.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                var admin = _unitOfWork.Users.All(nameof(User.Entitlements))
                    .SingleOrDefault(u => u.Email == email);
                var roles = admin.Entitlements
                    .Select(e => _unitOfWork.Roles.FindAsync(e.RoleId).Result);

                var countOfAdminRolesroles = roles.Count(r => r.Name.StartsWith(Constants.Admin));
                if (countOfAdminRolesroles == 0)
                    return Task.CompletedTask;
                if (countOfAdminRolesroles == 2)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }

                var roleGroup = roles.SingleOrDefault(r => r.Name.StartsWith(Constants.Admin))
                                    ?.Name.Substring(Constants.Admin.Length) ?? throw new NullReferenceException();

                int userId;
                if (mvcContext.HttpContext.Request.Method == Constants.Get)
                {
                    if (mvcContext.RouteData.Values.TryGetValue(Constants.UserId, out var id))
                        userId = Convert.ToInt32(id);
                    else
                        return Task.CompletedTask;
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        mvcContext.HttpContext.Request.Body.CopyTo(stream);
                        var json = Encoding.UTF8.GetString(stream.ToArray());
                        try
                        {
                            var viewModel = JsonConvert.DeserializeObject<UserViewModel>(json);
                            userId = viewModel.Id.Value;
                        }
                        catch
                        {
                            return Task.CompletedTask;
                        }
                    }
                    mvcContext.HttpContext.Request.Body.Position = 0;
                }

                var user = _unitOfWork.Users.FindAsync(userId, nameof(User.Entitlements)).Result ??
                           throw new NullReferenceException();
                roles = user.Entitlements.Select(e => _unitOfWork.Roles.FindAsync(e.RoleId).Result);
                if (!roles.Any(r => !r.Name.StartsWith(Constants.Admin) && r.Name.EndsWith(roleGroup)))
                    return Task.CompletedTask;
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
