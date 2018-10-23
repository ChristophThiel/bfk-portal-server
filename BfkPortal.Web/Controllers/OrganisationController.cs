using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BfkPortal.Web.ViewModels;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _service;

        public OrganisationController(IOrganisationService service)
        {
            _service = service;
        }

        [Authorize(Roles = "AdminBfk")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] OrganisationViewModel viewModel)
        {
            var id = await _service.Add(viewModel);
            return Ok(id);
        }

        [HttpGet("[action]")]
        public IActionResult All()
        {
            var organisationDtos = _service.All();
            return Ok(organisationDtos);
        }

        [Authorize(Roles = "AdminBfk")]
        [HttpGet("[action]/{organisationId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int organisationId)
        {
            await _service.Remove(organisationId);
            return Ok();
        }

        [HttpGet("[action]/{organisationId:int}")]
        public async Task<IActionResult> Find(int organisationId)
        {
            return Ok(await _service.Find(organisationId));
        }

        [Authorize(Roles = "AdminBfk")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] OrganisationViewModel viewModel)
        {
            var id = await _service.Update(viewModel);
            return Ok(id);
        }
    }
}
