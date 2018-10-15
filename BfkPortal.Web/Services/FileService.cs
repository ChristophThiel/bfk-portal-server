using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BfkPortal.Web.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<string> All()
        {
            return _unitOfWork.Files.All()
                .Select(f => f.FileName);
        }

        public async Task Delete(int fileId, string email)
        {
            var user = _unitOfWork.Users.All(nameof(User.Possessions), nameof(User.Entitlements))
                .SingleOrDefault(u => u.Email == email);

            if (user.Possessions.Count <= 0)
                throw new Exception();

            for (var i = 0; i < user.Possessions.Count; i++)
            {
                var possession = user.Possessions.ElementAt(i);
                var file = await _unitOfWork.Files.FindAsync(possession.FileId);
                if (file.Id == fileId && file.OwnerId == user.Id ||
                    user.Entitlements.Any(e =>
                        _unitOfWork.Roles.FindAsync(e.RoleId).Result.Name.StartsWith(Constants.Admin)))
                {
                    System.IO.File.Delete(file.Path);
                    _unitOfWork.Files.Remove(file);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
        }

        public async Task Upload(IFormFile file, string email)
        {
            var owner = _unitOfWork.Users.All(nameof(User.Possessions))
                .SingleOrDefault(u => u.Email == email);

            var fileName = await CreateFile(file, owner);

            var now = DateTime.Now;
            var model = new Core.Models.File
            {
                FileName = fileName,
                Path = Path.Combine(CreatePath(owner.Email), fileName),
                Created = now,
                LastModified = now,
                Owner = owner
            };
            _unitOfWork.Files.Add(model);
            owner.Possessions.Add(new Possession
            {
                User = owner,
                File = model
            });

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<string> CreateFile(IFormFile file, User owner)
        {
            if (file.Length <= 0)
                throw new Exception();

            var path = CreatePath(owner.Email);
            Directory.CreateDirectory(path);

            var fileName = string.IsNullOrEmpty(file.FileName) ? $"File {owner.Possessions.Count() + 1}" : file.FileName;
            path = Path.Combine(path, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        private string CreatePath(string email)
        {
            return Path.Combine(_hostingEnvironment.ContentRootPath, Constants.FileStorageFolderName, email);
        }
    }
}
