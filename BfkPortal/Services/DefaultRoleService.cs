using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Services
{
    public class DefaultRoleService
    {
        public const string UserBfk = "UserBfk";
        public const string AdminBfk = "AdminBfk";
        public const string UserBwst = "UserBwst";
        public const string ObserverBwst = "ObserverBwst";
        public const string AdminBwst = "AdminBwst";

        public static bool ContainsRole(User user, string role)
        {
            var result = user.Roles.First(ur => ur.Role.Name == role);
            return result != null;
        }

        public static bool ContainsRole(User user, string[] roles) =>
            user.Roles.Any(ur => roles.Any(role => ur.Role.Name == role));
    }
}
