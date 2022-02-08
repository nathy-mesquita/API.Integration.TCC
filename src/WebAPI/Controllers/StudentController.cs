using API.Integration.TCC.Application.Commands.CreateStudent;
using API.Integration.TCC.Application.Commands.LoginStudent;
using API.Integration.TCC.Application.Queries.GetAllStudent;
using API.Integration.TCC.Application.Queries.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Integration.TCC.WebAP.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IMediator mediator, ILogger<StudentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Busca todos os alunos cadastrados
        /// </summary>
        /// <param name="query">query</param>
        /// <returns>Lista de Alunos</returns>
        [HttpGet]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> Get(string query)
        {
            var getAllStudentQuery = new GetAllStudentQuery(query);
            var students = await _mediator.Send(getAllStudentQuery);
            if (students is null) return NotFound();
            return Ok(students);
        }


        /// <summary>
        /// Busca um Aluno por Id 
        /// </summary>
        /// <param name="id">Identificador do aluno</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var student = await _mediator.Send(query);
            if (student is null) return NotFound();
            return Ok(student);
        }

        /// <summary>
        /// Cria um cadastro de Aluno
        /// </summary>
        /// <param name="command">Informações do aluno</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="command">Informações do aluno</param>
        /// <returns></returns>
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] LoginStudentCommand command)
        {
            var loginStudentViewModel = await _mediator.Send(command);
            if (loginStudentViewModel is null) return BadRequest();
            return Ok(loginStudentViewModel);
        }
    }
}