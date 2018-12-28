using HolidayApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HolidaysController : ControllerBase
    {
        [HttpGet("{year:int}")]
        public IActionResult All(int year)
        {
            var calculator = new HolidayCalculator(year);
            return Ok(calculator.ExportHolidays());
        }
    }
}
