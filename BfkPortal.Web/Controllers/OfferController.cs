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
            var id = await _service.Add(viewModel);
            return Ok(id);
        }

        [HttpGet("[action]")]
        public IActionResult All()
        {
            var offerDtos = _service.All();
            return Ok(offerDtos);
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [HttpGet("[action]/{offerId:int}")]
        public async Task<IActionResult> Delete(int offerId)
        {
            await _service.Remove(offerId);
            return Ok();
        }

        [HttpGet("[action]/{offerId:int}")]
        public async Task<IActionResult> Find(int offerId)
        {
            var dto = await _service.Find(offerId);
            return Ok(dto);
        }

        [HttpGet("[action]")]
        public IActionResult Status()
        {
            return Ok(_service.Status());
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Reply([FromBody] OfferReplyViewModel viewModel)
        {
            await _service.Reply(viewModel.OfferId.Value, viewModel.Status.Value);
            return Ok();
        }

        [Authorize(Roles = "AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] OfferViewModel viewModel)
        {
            await _service.Update(viewModel);
            return Ok();
        }
    }
}
