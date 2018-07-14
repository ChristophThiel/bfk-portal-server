using System;
using System.Runtime.CompilerServices;
using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using BfkPortal.Web.Models;
using BfkPortal.Web.Validation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthentificationController : Controller
    {
        // TODO Json is null
        // TODO JsonWebToken
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

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                /*context.Database.EnsureCreated();
                context.Users.Add(new User(0, "christoph.thiel@liwest.at", "test", "test"));*/
            }
            // Database

            return new Message("login", new {Success = true, Token = Guid.NewGuid().ToString()}).ToString();
        }

        [HttpGet]
        [Route("date")]
        public string Date([FromHeader] string token, [CallerMemberName] string action = "")
        {
            return Message.Error(action).ToString();
        }
    }
}