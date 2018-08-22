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

        public static bool ContainsRole(User user, string[] roles)
        {
            var count = 0;
            foreach (var ur in user.Roles)
            {
                foreach (var role in roles)
                {
                    if (count == roles.Length)
                        return true;
                    if (ur.Role.Name == role)
                        count++;
                }
            }
            return false;
        }
    }
}
