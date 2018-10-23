using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<User, UserDto> _modelToDtoConverter;
        private readonly IConverter<UserViewModel, User> _viewModelToModelConverter;

        public UserService(IUnitOfWork unitOfWork, IConverter<User, UserDto> modelToDtoConverter, IConverter<UserViewModel, User> viewModelToModelConverter)
        {
            _unitOfWork = unitOfWork;
            _modelToDtoConverter = modelToDtoConverter;
            _viewModelToModelConverter = viewModelToModelConverter;
        }

        public IEnumerable<UserDto> All()
        {
            return _unitOfWork.Users.All(nameof(User.Entitlements), nameof(User.Memberships)).Select(u => _modelToDtoConverter.Convert(u).Result);
        }

        public async Task Remove(int id)
        {
            var entity = (await _unitOfWork.Users.FindAsync(id)) ?? throw new NullReferenceException();
            entity.IsDeleted = true;
            _unitOfWork.Users.Update(entity);

            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<string> Roles()
        {
            return _unitOfWork.Roles.All().Select(r => r.Name);
        }

        public async Task Update(UserViewModel viewModel)
        {
            if (!viewModel.Id.HasValue)
                throw new NullReferenceException();

            var entity = (await _unitOfWork.Users.FindAsync(viewModel.Id.Value)) ?? throw new NullReferenceException();

            entity = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Users.Update(entity);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
