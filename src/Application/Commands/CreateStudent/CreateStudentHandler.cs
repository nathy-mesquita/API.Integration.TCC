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
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<CreateStudentHandler> _logger;

        public CreateStudentHandler(IStudentRepository studentRepository, IAuthService authService, ILogger<CreateStudentHandler> logger)
        {
            _studentRepository = studentRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando a criação de um aluno");
            var passwordHash = _authService.ComputeSha256Hash(request.Password!);
            var student = new Student(request.FullName, request.Email, passwordHash, request.Course, request.BirthDate);
            await _studentRepository.AddAsync(student);
            _logger.LogInformation($"Aluno criado Student= {student}");
            return student.Id;
        }
    }
}
