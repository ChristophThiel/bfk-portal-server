using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidaysService _service;

        public HolidaysController(IHolidaysService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok(_service.All(null));
        }

        [HttpGet("{year:int}")]
        public IActionResult All(int year)
        {
            return Ok(_service.All(year));
        }
    }
}
