using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services.Converters
{
    public class FileToFileDtoConverter : IConverter<Core.Models.File, FileDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FileToFileDtoConverter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FileDto> Convert(Core.Models.File source)
        {
            var destination = new FileDto
            {
                Id = source.Id,
                FileName = source.FileName,
                Path = source.Path,
                LastModified = source.LastModified.ToString("s"),
                Created = source.Created.ToString("s"),
                OwnerId = source.OwnerId
            };

            return destination;
        }
    }
}
