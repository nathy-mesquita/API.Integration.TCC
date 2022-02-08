using API.Integration.TCC.Application.Commands.CreateProjectTCC;
using API.Integration.TCC.Application.Commands.DeleteProjectTCC;
using API.Integration.TCC.Application.Commands.FinishProjectTCC;
using API.Integration.TCC.Application.Commands.StartProjectTCC;
using API.Integration.TCC.Application.Commands.UpdateProjectTCC;
using API.Integration.TCC.Application.Commands.UpdateTeacherAdvisor;
using API.Integration.TCC.Application.Queries.GetAllProjectTCC;
using API.Integration.TCC.Application.Queries.GetProjectTCCById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectTCCController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProjectTCCController> _logger;

        public ProjectTCCController(IMediator mediator, ILogger<ProjectTCCController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Busca todos os projetos
        /// </summary>
        /// <param name="query">Query de consulta</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsTCCQuery = new GetAllProjectTCCQuery(query);
            var projectsTCC = await _mediator.Send(getAllProjectsTCCQuery);
            if (projectsTCC is null) return NotFound();
            return Ok(projectsTCC);
        }

        /// <summary>
        /// Busca um projeto pelo Id
        /// </summary>
        /// <param name="id">Identificador único do projeto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectTCCByIdQuery(id);
            var projectTCC = await _mediator.Send(query);
            if (projectTCC is null) return NotFound();
            return Ok(projectTCC);
        }

        /// <summary>
        /// Cria um projeto
        /// </summary>
        /// <param name="command">Informações para criação do projeto</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student)]
        public async Task<IActionResult> Post([FromBody] CreateProjectTCCCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        /// <summary>
        /// Atribui um professor orientador a um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <param name="command">Informações a serem modificadas no projeto</param>
        /// <returns></returns>
        [HttpPut("{id}/teacher")]
        [Authorize(Roles = Roles.Teacher + "," + Roles.Student)]
        public async Task<IActionResult> PutTeacherAdvisor(int id, [FromBody] UpdateTeacherAdvisorCommand command)
        {
            //TODO: Como bloquear o Id do UpdateTeacherAdvisorCommand para não exibir para alteração do usuário
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Atualiza um projeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="command">Informações a serem modificadas no projeto</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectTCCCommand command)
        {
            //TODO: Como bloquear o Id do UpdateProjectTCCCommand para não exibir para alteração do usuário
            command.Id = id;
            if (command.Description!.Length > 250)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Exclui um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectTCCCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Inicia um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [HttpPut("{id}/start")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Start(int id)
        {

            var command = new StartProjectTCCCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Finaliza um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [HttpPut("{id}/finish")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectTCCCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}