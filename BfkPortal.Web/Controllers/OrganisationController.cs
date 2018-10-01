using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _service;

        public OrganisationController()
        {
            _service = new OrganisationService(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] OrganisationViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);
            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok(new {id});
        }

        [HttpGet("[action]/{organisationId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int organisationId)
        {
            var organisation = _service.Remove(organisationId);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] OrganisationViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Update(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult All() => Ok(_service.All());
    }
}
