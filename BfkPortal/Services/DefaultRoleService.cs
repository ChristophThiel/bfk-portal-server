using System;
using BfkPortal.Models;
using BfkPortal.Models.Enums;
using System.Linq;

namespace BfkPortal.Services
{
    public class DefaultRoleService
    {
        public static readonly Roles[] BfkRoles = new[] {Roles.UserBfk, Roles.AdminBfk};
        public static readonly Roles[] BwstRoles = new[] {Roles.UserBwst, Roles.ObserverBwst, Roles.AdminBwst};

        public static bool RequireRoles(Roles[] requiredRoles, User user)
        {
            if (user?.Roles == null)
                return false;

            var roles = user.Roles.Where(ur => ur.Role != null)
                .Select(ur => ur.Role)
                .ToList();
            if (!roles.Any())
                return false;

            foreach (var role in roles)
            {
                if (requiredRoles.Contains(Enum.Parse<Roles>(role.Name)))
                    return true;
            }

            return false;
        }

        public static bool HasRole(Roles role, User user)
        {
            if (user?.Roles == null)
                return false;

            var roles = user.Roles.Where(ur => ur.Role != null)
                .Select(ur => ur.Role.Name)
                .ToList();

            return roles.Any() && roles.Contains(role.ToString());
        }
    }
}
