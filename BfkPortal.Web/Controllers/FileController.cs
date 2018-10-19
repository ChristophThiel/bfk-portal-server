using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _service;

        public FileController(IFileService service)
        {
            _service = service;
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                await _service.Upload(file, email);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpGet("[action]/{fileId:int}")]
        public async Task<IActionResult> Delete(int fileId)
        {
            try
            {
                var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                await _service.Delete(fileId, email);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("[action]")]
        public IActionResult All()
        {
            try
            {
                var files = _service.All();
                return Ok(files);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
