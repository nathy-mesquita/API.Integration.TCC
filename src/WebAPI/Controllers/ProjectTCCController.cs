using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectTCCController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectTCCController(IMediator mediator) => _mediator = mediator;
    
    // GET: api/projects?query=netCore
        [HttpGet]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> Get(string query)
        {
            // var getAllProjectsQuery = new GetAllProjectsQuery(query);
            // var projects = await _mediator.Send(getAllProjectsQuery);
            // if(projects is null) return NotFound();
            // return Ok(projects);
            return Ok();
        }

        // GET api/projets/id
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> GetById(int id)
        {
            // var query = new GetProjectQuery(id);
            // var project = await _mediator.Send(query);
            // if (project is null) return NotFound();
            // return Ok(project);
            return Ok();
        }

        // POST projects
        [HttpPost]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student)]
        public async Task<IActionResult> Post([FromBody] string command)
        {
            //[FromBody] CreateProjectCommand command
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        // PUT api/projects/id
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Put(int id, [FromBody] string command)
        {
            //[FromBody] UpdateProjectCommand command
            // if (command.Description.Length > 200)
            // {
            //     return BadRequest();
            // }
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/projects/id
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Delete(int id)
        {
            // var command = new DeleteProjectCommand(id);
            // await _mediator.Send(command);
            return NoContent();
        }

        // POST api/projects/id/comments
        [HttpPost("{id}/comments")]
        [Authorize(Roles = Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> PostComment(int id, [FromBody] string command)
        {
            //[FromBody] CreateCommentCommand command
            // 400 - return BadRequest();
            //await _mediator.Send(command);
            return NoContent(); //204
        }

        // PUT api/projects/id/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Start(int id)
        {
            // var command = new StartProjectCommand(id);
            // await _mediator.Send(command);
            return NoContent(); //204
        }

        //PUT api/projects/id/finish
        [HttpPut("{id}/finish")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Finish(int id)
        {
            // var command = new FinishProjectCommand(id);
            // await _mediator.Send(command);
            return NoContent(); //204
        }
    }
}