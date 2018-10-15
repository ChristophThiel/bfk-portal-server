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

        [Authorize(Roles = "AdminBfk")]
        [HttpGet("[action]/{organisationId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int organisationId)
        {
            try
            {
                await _service.RemoveAsync(organisationId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "AdminBfk")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] OrganisationViewModel viewModel)
        {
            try
            {
                var id = await _service.UpdateAsync(viewModel);
                return Ok(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{organisationId:int}")]
        public async Task<IActionResult> Find([FromHeader] int organisationId)
        {
            try
            {
                return Ok(await _service.FindAsync(organisationId));
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
                var organisationDtos = _service.All();
                return Ok(organisationDtos);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
