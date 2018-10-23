using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BfkPortal.Web.Contracts
{
    public interface IFileService
    {
        IEnumerable<string> All();

        Task Remove(int fileId, string email);

        Task Upload(IFormFile file, string email);
    }
}
