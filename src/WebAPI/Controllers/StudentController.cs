using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

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

        //GET api/Student?query=netCore
        /// <summary>
        /// Busca todos os alunos cadastrados
        /// </summary>
        /// <param name="query">query</param>
        /// <returns>Lista de Alunos</returns>
        [HttpGet]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Student + "," + Roles.Teacher)]
        public async Task<IActionResult> Get(string query)
        {
           // var getAllProjectsQuery = new GetAllProjectsQuery(query);
            // var projects = await _mediator.Send(getAllProjectsQuery);
            // if(projects is null) return NotFound();
            //return Ok(projects);
            return Ok();
        } 

        //GET api/Student/matricula
        /// <summary>
        /// Busca um Aluno por matricula 
        /// </summary>
        /// <param name="matricula">Matricula</param>
        /// <returns></returns>
        [HttpGet("{matricula}")]
        [Authorize(Roles= Roles.Administrador)]
        public async Task<IActionResult> GetByEnrollment(string matricula)
        {
            // var query = new GetUserQuery(id);
            // var user = await _mediator.Send(query);
            // if(user is null) return NotFound();
            //return Ok(user); //200
            return Ok(); 
        }  

        // POS api/Student
        /// <summary>
        /// Cria um cadastro de Aluno
        /// </summary>
        /// <param name="command">Informações do aluno</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] string command)
        {
            //[FromBody] CreateUserCommand command
            // var id = await _mediator.Send(command);
            // return CreatedAtAction(nameof(GetById), new { id = id }, command);
            return Ok();
        }

        //PUT api/Student/login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="command">Informações do aluno</param>
        /// <returns></returns>
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] string command)
        {
            //[FromBody] LoginUserCommand command
            // var loginUserViewModel = await _mediator.Send(command);
            // if (loginUserViewModel is null) return BadRequest();
            // return Ok(loginUserViewModel);
            return Ok();
        }
    }
}