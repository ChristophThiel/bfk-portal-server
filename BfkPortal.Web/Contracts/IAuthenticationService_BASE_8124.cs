using System.Threading.Tasks;
using BfkPortal.Persistence.Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Web.Contracts
{
    public interface IAuthenticationService
    {
        IConfiguration Configuration { get; }

        IUnitOfWork UnitOfWork { get; }

        ModelStateDictionary ModelState { get; }

        Task<string> CreateJsonWebTokenAsync(int id);

        Task<int> VerifyPassword(string email, string password);
    }
}
