using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _service;

        public OfferController()
        {
            _service = new OfferService(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] OfferViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok(new {id});
        }

        [HttpGet("[action]/{offerId:int}")]
        public async Task<IActionResult> Delete(int offerId)
        {
            await _service.Remove(offerId);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] OfferViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Update(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult All() => Ok(_service.All());

        [HttpGet("[action]")]
        public IActionResult Status() => Ok(_service.Status());

        [HttpPost("[action]")]
        public async Task<IActionResult> Reply([FromBody] OfferReplyViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.ReplyAsync(body.OfferId.Value, body.Status.Value);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        } 
    }
}
