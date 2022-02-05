using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.CreateTeacher
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<CreateTeacherHandler> _logger;

        public CreateTeacherHandler(ITeacherRepository teacherRepository, IAuthService authService, ILogger<CreateTeacherHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando a criação de um professor");
            var passwordHash = _authService.ComputeSha256Hash(request.Password!);
            var teacher = new Teacher(request.FullName, request.Email, passwordHash, request.BirthDate, request.Specialty, request.SubjectsTaught);
            await _teacherRepository.AddAsync(teacher);
            _logger.LogInformation($"Professor criado Teacher= {teacher}");
            return teacher.Id;
        }
    }
}
