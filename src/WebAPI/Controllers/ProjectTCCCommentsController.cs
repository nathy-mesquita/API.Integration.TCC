using API.Integration.TCC.Application.Commands.CreateComment;
using API.Integration.TCC.Application.Commands.DeleteComment;
using API.Integration.TCC.Application.Commands.UpdateComment;
using API.Integration.TCC.Application.Queries.GetCommentsById;
using API.Integration.TCC.Application.Queries.GetCommentsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectTCCCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProjectTCCCommentsController> _logger;

        public ProjectTCCCommentsController(IMediator mediator, ILogger<ProjectTCCCommentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Busca um comentário pelo Id
        /// </summary>
        /// <param name="id">Identificador único comentário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCommentsByIdQuery(id);
            var comment = await _mediator.Send(query);
            if (comment is null) return NotFound();
            return Ok(comment);
        }

        /// <summary>
        /// Busca dos comentários pelo Id do projeto
        /// </summary>
        /// <param name="id">Identificador único do projeto</param>
        /// <returns></returns>
        [HttpGet("{id}/project")]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> GetByIdProject(int id)
        {
            var query = new GetCommentsQuery(id);
            var comments = await _mediator.Send(query);
            if (comments is null) return NotFound();
            return Ok(comments);
        }

        /// <summary>
        /// Realiza um comentário no projeto
        /// </summary>
        /// <param name="command">Conteúdo do comentário</param>
        /// <returns></returns>
        [HttpPost("{id}/project")]
        [Authorize(Roles = Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        /// <summary>
        /// Atualiza um comentário de projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <param name="command">Informações a serem modificadas no projeto</param>
        /// <returns></returns>
        [HttpPut("{id}/project")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCommentCommand command)
        {
            //TODO: Codereview
            command.Id = id;
            if (command.Content!.Length > 250)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Exclui um comentário de projeto
        /// </summary>
        /// <param name="id">Identificador do comentário</param>
        /// <returns></returns>
        [HttpDelete("{id}/project")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

    }
}