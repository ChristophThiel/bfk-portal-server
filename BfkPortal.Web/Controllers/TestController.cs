using BfkPortal.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Appointment body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok("Worked!");
        }
    }
}
