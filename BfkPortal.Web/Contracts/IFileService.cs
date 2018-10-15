using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BfkPortal.Web.Contracts
{
    public interface IFileService
    {
        Task Upload(IFormFile file, string email);

        Task Delete(int fileId, string email);

        IEnumerable<string> All();

    }
}
