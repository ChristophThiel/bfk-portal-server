using System;
using System.Linq;
using System.Runtime.CompilerServices;
using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using BfkPortal.Web.DataTransferObjects;
using BfkPortal.Web.Models;
using BfkPortal.Web.Services;
using BfkPortal.Web.Validation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        [HttpGet]
        [Route("test")]
        public string Test([CallerMemberName] string action = "") =>  new Message(action, new {Success = true}).ToString();

        [HttpPost]
        [Route("login")]
        public string Login([FromBody] Message body, [CallerMemberName] string action = "")
        {
            if (!CommuncationValidator.ValidateBody(body))
                return Message.Error(action).ToString();

            var definition = new {Email = "", Password = ""};
            if (!CommuncationValidator.ValidatePayload(body.PayLoad.ToString(), definition))
                return Message.Error(action).ToString();

            var payload = JsonConvert.DeserializeAnonymousType(body.PayLoad.ToString(), definition);

            User user;
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    user = context.Users.First(u =>
                        u.Email == payload.Email &&
                        PasswordValidator.ValidatePassword(payload.Password, u.Salt, u.Password));
                }
                catch (Exception)
                {
                    return Message.Error(action).ToString();
                }
            }

            var token = JsonWebTokenService.GenerateToken(user.Email);
            return new Message("login", new {Success = true, Token = token, User = new UserDto(user)}).ToString();
        }

        [HttpGet]
        [Route("date")]
        public string Date([FromHeader] string token, [CallerMemberName] string action = "")
        {
            return Message.Error(action).ToString();
        }
    }
}