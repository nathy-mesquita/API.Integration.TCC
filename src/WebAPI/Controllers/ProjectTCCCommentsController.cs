using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectTCCCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectTCCCommentsController(IMediator mediator) => _mediator = mediator;

        
    }
}