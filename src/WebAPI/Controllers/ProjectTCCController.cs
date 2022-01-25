using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectTCCController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectTCCController(IMediator mediator) => _mediator = mediator;
    
        // GET: api/projects?query=netCore
        /// <summary>
        /// Busca todos os projetos
        /// </summary>
        /// <param name="query">Query de consulta</param>
        /// <returns></returns>
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
        /// <summary>
        /// Busca um projeto pelo Id
        /// </summary>
        /// <param name="id">Identificador único do projeto</param>
        /// <returns></returns>
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
        /// <summary>
        /// Cria um projeto
        /// </summary>
        /// <param name="command">Informações para criação do projeto</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student)]
        public async Task<IActionResult> Post([FromBody] string command)
        {
            //[FromBody] CreateProjectCommand command
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        // PUT api/projects/id/teacher
        /// <summary>
        /// Atribui um professor orientador a um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <param name="command">Informações a serem modificadas no projeto </param>
        /// <returns></returns>
        [HttpPut("{id}/teacher")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> PutTeacherAdvisor(int id, [FromBody] string command)
        {
            //[FromBody] UpdateProjectCommand command
            // if (command.Description.Length > 200)
            // {
            //     return BadRequest();
            // }
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/projects/id
        /// <summary>
        /// Atualiza um projeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="command">Informações a serem modificadas no projeto </param>
        /// <returns></returns>
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
        /// <summary>
        /// Exclui um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Delete(int id)
        {
            // var command = new DeleteProjectCommand(id);
            // await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/projects/id/start
        /// <summary>
        /// Inicia um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [HttpPut("{id}/start")]
        [Authorize(Roles = Roles.Student)]
        public async Task<IActionResult> Start(int id)
        {
            // var command = new StartProjectCommand(id);
            // await _mediator.Send(command);
            return NoContent(); //204
        }

        //PUT api/projects/id/finish
        /// <summary>
        /// Finaliza um projeto
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
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