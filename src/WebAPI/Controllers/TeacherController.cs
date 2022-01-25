using MediatR;
using System.Threading.Tasks;
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

        // GET: api/projects?query=netCore
        /// <summary>
        /// Busca todos os professores cadastrados
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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

        //GET api/Teacher/id
        /// <summary>
        /// Busca um Professor por identificador 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles= Roles.Administrador)]
        public async Task<IActionResult> GetById(int id)
        {
            // var query = new GetUserQuery(id);
            // var user = await _mediator.Send(query);
            // if(user is null) return NotFound();
            //return Ok(user); //200
            return Ok(); 
        }   

        // POS api/Teacher
        /// <summary>
        /// Cria um cadastro de professor
        /// </summary>
        /// <param name="command">Informações do professor</param>
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


        //PUT api/Teacher/login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="command">Informações do professor</param>
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