using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
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
            return Ok(await _unitOfWork.Organisations.All());
        }
    }
}
