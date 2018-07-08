using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthentificationController : Controller
    {
        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "This is a message!";
        }
    }
}