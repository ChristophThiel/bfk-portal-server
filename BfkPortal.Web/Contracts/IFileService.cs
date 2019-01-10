using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace BfkPortal.Web.Contracts
{
    public interface IFileService
    {
        IEnumerable<FileDto> All();

        Task<(string, byte[])> Download(int fileId);

        Task Remove(int fileId, string email);

        Task Upload(IFormFile file, string email);
    }
}
