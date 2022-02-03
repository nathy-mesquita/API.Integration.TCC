using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.LoginStudent
{
    public class LoginStudentHandler : IRequestHandler<LoginStudentCommand, LoginStudentViewModel>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<LoginStudentHandler> _logger;

        public LoginStudentHandler(IStudentRepository studentRepository, IAuthService authService, ILogger<LoginStudentHandler> logger)
        {
            _studentRepository = studentRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<LoginStudentViewModel> Handle(LoginStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando o Handler de login de um aluno");

            _logger.LogInformation("Utilizando altoritmo para criar Hash de senha");
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            _logger.LogInformation("Buscando no banco um Student que tenha o meu email e senha no formato Hash");
            var student = await _studentRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (student is null)
            {
                _logger.LogError("Erro no login");
                return null;
            }

            _logger.LogInformation("Gerando o token passando os dados do aluno");
            var token = _authService.GenereteJwtToken(student.Email, student.Role);

            var loginStudentViewModel = new LoginStudentViewModel(student.Email, token);
            _logger.LogInformation($"Resultado: loginStudentViewModel={loginStudentViewModel}");

            return loginStudentViewModel;
        }
    }
}
