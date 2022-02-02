using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<CreateStudentCommandHandler> _logger;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IAuthService authService, ILogger<CreateStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando a criação de um aluno");
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var student = new Student(request.FullName, request.Email, passwordHash, request.Course, request.BirthDate);
            await _studentRepository.AddAsync(student);
            _logger.LogInformation($"Aluno criado = {student}");
            return student.Enrollment;
        }
    }
}
