using System.Collections.Generic;
using System.Linq;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<User, UserDto> _modelToDtoConverter;

        public UserService(IUnitOfWork unitOfWork, IConverter<User, UserDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _modelToDtoConverter = modelToDtoConverter;
        }

        public IEnumerable<UserDto> All()
        {
            return _unitOfWork.Users.All(nameof(User.Entitlements), nameof(User.Memberships)).Select(u => _modelToDtoConverter.Convert(u).Result);
        }

        public IEnumerable<string> Roles()
        {
            return _unitOfWork.Roles.All().Select(r => r.Name);
        }
    }
}
