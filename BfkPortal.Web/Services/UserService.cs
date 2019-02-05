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
            return _unitOfWork.Users.All(nameof(User.Entitlements), nameof(User.Memberships), nameof(User.Preferences))
                .Select(u => _modelToDtoConverter.Convert(u).Result);
        }

        public IEnumerable<UserDto> AllUsersOfSameRoleGroup(params string[] roles)
        {
            var roleGroups = new List<string>();
            if (roles.Any(r => r == Constants.UserBfk || r == Constants.AdminBfk))
                roleGroups.AddRange(new[] { Constants.UserBfk, Constants.AdminBfk });
            if (roles.Any(r => r == Constants.AdminBwst))
                roleGroups.AddRange(new[] { Constants.ObserverBwst, Constants.UserBwst, Constants.AdminBwst });

            var userIds = _unitOfWork.Entitlements.All(nameof(Entitlement.User), nameof(Entitlement.Role))
                .GroupBy(e => e.UserId)
                .Where(grouped => roleGroups.Any(r => grouped.Any(g => g.Role.Name == r)))
                .Select(grouped => grouped.Key);

            return userIds.Select(id => _modelToDtoConverter.Convert(_unitOfWork.Users.FindAsync(id, nameof(User.Entitlements), nameof(User.Memberships), nameof(User.Preferences)).Result).Result);
        }

        public async Task<string> GetToken(int id)
        {
            var user = (await _unitOfWork.Users.FindAsync(id)) ?? throw new NullReferenceException();
            return user.NotificationToken ?? throw new NullReferenceException();
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

        public IEnumerable<string> RolesOfRoleGroup(params string[] roles)
        {
            var roleGroups = new List<string>();
            if (roles.Any(r => r == Constants.AdminBfk))
                roleGroups.Add(Constants.Bfk);
            if (roles.Any(r => r == Constants.AdminBwst))
                roleGroups.Add(Constants.Bwst);

            return _unitOfWork.Roles.All()
                .Where(r => roleGroups.Any(roleGroup => r.Name.EndsWith(roleGroup)))
                .Select(r => r.Name);
        }

        public async Task SetToken(int id, string token)
        {
            var user = (await _unitOfWork.Users.FindAsync(id)) ?? throw new NotImplementedException();
            user.NotificationToken = token;

            await _unitOfWork.SaveChangesAsync();
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
