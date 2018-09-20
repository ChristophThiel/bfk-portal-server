using BfkPortal.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Appointment value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Worked!");
        }
    }
}
