using BfkPortal.Core.Contracts;
using BfkPortal.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController()
        {
            _service = new AppointmentService();
        }
    }
}
