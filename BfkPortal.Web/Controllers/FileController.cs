using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
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

        [HttpGet("[action]")]
        public IActionResult All()
        {
            var fileDtos = _service.All().ToList();
            return Ok(fileDtos);
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpGet("[action]/{fileId:int}")]
        public async Task<IActionResult> Delete(int fileId)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            await _service.Remove(fileId, email);
            return Ok();
        }
        
        [HttpGet("[action]/{fileId:int}")]
        public async Task<IActionResult> Download(int fileId)
        {
            var result = await _service.Download(fileId);
            return File(result.Item2, Constants.FileContentType, result.Item1);
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile model)
        {
            if (model.Length > Constants.FileContentLength)
                throw new Exception("File is to big for uploading.");

            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            await _service.Upload(model, email);
            return Ok();
        }
    }
}
