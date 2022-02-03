using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.LoginTeacher
{
    public class LoginTeacherHandler : IRequestHandler<LoginTeacherCommand, LoginTeacherViewModel>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<LoginTeacherHandler> _logger;

        public LoginTeacherHandler(ITeacherRepository teacherRepository, IAuthService authService, ILogger<LoginTeacherHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<LoginTeacherViewModel> Handle(LoginTeacherCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando o Handler de login de um professor");

            _logger.LogInformation("Utilizando altoritmo para criar Hash de senha");
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            _logger.LogInformation("Buscando no banco um Student que tenha o meu email e senha no formato Hash");
            var teacher = await _teacherRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (teacher is null)
            {
                _logger.LogError("Erro no login");
                return null;
            }

            _logger.LogInformation("Gerando o token passando os dados do professor");
            var token = _authService.GenereteJwtToken(teacher.Email, teacher.Role);

            var loginTeacherViewModel = new LoginTeacherViewModel(teacher.Email, token);
            _logger.LogInformation($"Resultado: loginTeacherViewModel={loginTeacherViewModel}");

            return loginTeacherViewModel;
        }
    }
}
