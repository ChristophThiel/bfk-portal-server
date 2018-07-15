using System.Linq;
using BfkPortal.Web.Services;

namespace BfkPortal.Web.Validation
{
    public class PasswordValidator
    {
        public static bool ValidatePassword(string password, string salt, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                return false;

            if (string.IsNullOrEmpty(salt) || string.IsNullOrWhiteSpace(salt))
                return false;

            if (string.IsNullOrEmpty(hash) || string.IsNullOrWhiteSpace(hash))
                return false;

            return PasswordHashingService.HashPassword(password, salt) == hash;
        }
    }
}
