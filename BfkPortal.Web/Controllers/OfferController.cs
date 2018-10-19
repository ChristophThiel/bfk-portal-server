using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _service;

        public OfferController(IOfferService service)
        {
            _service = service;
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] OfferViewModel viewModel)
        {
            try
            {
                var id = await _service.AddAsync(viewModel);
                return Ok(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [HttpGet("[action]/{offerId:int}")]
        public async Task<IActionResult> Delete(int offerId)
        {
            try
            {
                await _service.RemoveAsync(offerId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] OfferViewModel viewModel)
        {
            try
            {
                await _service.UpdateAsync(viewModel);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{offerId:int}")]
        public async Task<IActionResult> Find(int offerId)
        {
            try
            {
                var dto = await _service.FindAsync(offerId);
                return Ok(dto);
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
                var offerDtos = _service.All();
                return Ok(offerDtos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public IActionResult Status()
        {
            try
            {
                return Ok(_service.Status());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Reply([FromBody] OfferReplyViewModel viewModel)
        {
            try
            {
                await _service.ReplyAsync(viewModel.OfferId.Value, viewModel.Status.Value);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
