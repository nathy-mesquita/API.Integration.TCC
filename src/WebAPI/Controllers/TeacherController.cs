using API.Integration.TCC.Application.Commands.CreateTeacher;
using API.Integration.TCC.Application.Commands.LoginTeacher;
using API.Integration.TCC.Application.Queries.GetAllTeacher;
using API.Integration.TCC.Application.Queries.GetTeacherById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(IMediator mediator, ILogger<TeacherController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Busca todos os professores cadastrados
        /// </summary>
        /// <param name="query">query</param>
        /// <returns>Lista de professores</returns>
        [HttpGet]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> Get(string query)
        {
            var getAllTeachertQuery = new GetAllTeacherQuery(query);
            var teachers = await _mediator.Send(getAllTeachertQuery);
            if (teachers is null) return NotFound();
            return Ok(teachers);
        }

        /// <summary>
        /// Busca um Professor por identificador 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Administrador)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTeacherByIdQuery(id);
            var teacher = await _mediator.Send(query);
            if (teacher is null) return NotFound();
            return Ok(teacher);
        }

        /// <summary>
        /// Cria um cadastro de professor
        /// </summary>
        /// <param name="command">Informações do professor</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateTeacherCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="command">Informações do professor</param>
        /// <returns></returns>
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] LoginTeacherCommand command)
        {
            var loginTeacherViewModel = await _mediator.Send(command);
            if (loginTeacherViewModel is null) return BadRequest();
            return Ok(loginTeacherViewModel);
        }
    }
}