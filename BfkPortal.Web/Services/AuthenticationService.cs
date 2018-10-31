using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Security;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IConverter<UserViewModel, User> _userViewModelToUserConverter;
        private readonly IConverter<User, UserDto> _userToUserDtoConverter;

        public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration, IConverter<UserViewModel, User> userViewModelToUserConverter, IConverter<User, UserDto> userToUserDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _userViewModelToUserConverter = userViewModelToUserConverter;
            _userToUserDtoConverter = userToUserDtoConverter;
        }

        public async Task<UserDto> LogIn(CredentialsViewModel viewModel)
        {
            var user = _unitOfWork.Users.All(nameof(User.Entitlements), nameof(User.Memberships))
                .SingleOrDefault(u => u.Email == viewModel.Email) ?? throw new Exception("Invalid email or password.");

            var hasher = new Pbkdf2PasswordHasher();
            if (hasher.VerifyHashedPassword(user, user.Password, viewModel.Password) == PasswordVerificationResult.Failed)
                throw new Exception(Constants.InvalidCredentialsExceptionMessage);
            return await _userToUserDtoConverter.Convert(user);
        }

        public object GenerateJsonWebToken(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, user.Firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var roleClaims = user.Entitlements
                .Select(e => new Claim(ClaimTypes.Role, e));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Issuer"], claims,
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Register(UserViewModel viewModel)
        {
            var user = await _userViewModelToUserConverter.Convert(viewModel);
            if (_unitOfWork.Users.All().Any(u => u.Email == user.Email))
                throw new Exception(Constants.EmailAlreadyUsedExceptionMessage);

            var hasher = new Pbkdf2PasswordHasher();
            user.Salt = hasher.GenerateSalt();
            user.Password = hasher.HashPassword(user, viewModel.Password);

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
