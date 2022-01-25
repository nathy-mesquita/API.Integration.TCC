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

        
        // GET api/ProjectTCCComments/id/project
        /// <summary>
        /// Busca dos comentários pelo Id do projeto
        /// </summary>
        /// <param name="id">Identificador único do projeto</param>
        /// <returns></returns>
        [HttpGet("{id}/project")]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> GetByIdProject(int id)
        {
            // var query = new GetProjectQuery(id);
            // var project = await _mediator.Send(query);
            // if (project is null) return NotFound();
            // return Ok(project);
            return Ok();
        }
        
        
        // POST api/ProjectTCCComments/id/project
        /// <summary>
        /// Realiza um comentário no projeto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("{id}/project")]
        [Authorize(Roles = Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> PostComment(int id, [FromBody] string command)
        {
            //[FromBody] CreateCommentCommand command
            // 400 - return BadRequest();
            //await _mediator.Send(command);
            return NoContent(); //204
        }

        // PUT api/ProjectTCCComments/id/project
        /// <summary>
        /// Atualiza um comentário de projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <param name="command">Informações a serem modificadas no projeto</param>
        /// <returns></returns>
        [HttpPut("{id}/project")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Put(int id, [FromBody] string command)
        {
            //[FromBody] UpdateProjectCommentCommand command
            // if (command.Description.Length > 200)
            // {
            //     return BadRequest();
            // }
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/ProjectTCCComments/id/project
        /// <summary>
        /// Exclui um comentário de projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [HttpDelete("{id}/project")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Delete(int id)
        {
            // var command = new DeleteProjectCommand(id);
            // await _mediator.Send(command);
            return NoContent();
        }

    }
}