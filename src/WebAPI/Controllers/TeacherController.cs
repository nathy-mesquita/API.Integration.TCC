using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeacherController(IMediator mediator) => _mediator = mediator;
    }
}