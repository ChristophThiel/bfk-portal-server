using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using BfkPortal.Web.Security;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class UserService : IUserService<User, UserViewModel>
    {
        private readonly ModelStateDictionary _modelState;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(ModelStateDictionary modelState)
        {
            this._modelState = modelState;
            this._unitOfWork = new UnitOfWork();
        }

        public async Task<int> Add(UserViewModel viewModel)
        {
            var hasher = new Pbkdf2PasswordHasher();
            var salt = hasher.GenerateSalt();

            var entity = new User
            {
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname,
                Email = viewModel.Email,
                Salt = salt,
                IsDeleted = viewModel.IsDeleted ?? false
            };

            var password = hasher.HashPassword(entity, viewModel.Password);
            entity.Password = password;

            // TODO Add Entitlements and Memberships

            _unitOfWork.Users.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            var test = await _unitOfWork.Users.FindAsync(entity.Id);

            return entity.Id;
        }
    }
}
