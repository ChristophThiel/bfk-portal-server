using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Database.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganisationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var organisations = await _unitOfWork.Organisations.All();
            return Ok(organisations.Select(o => new OrganisationDto(o)));
        }
    }
}
