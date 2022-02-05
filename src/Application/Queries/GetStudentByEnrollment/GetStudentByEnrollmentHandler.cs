using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetStudentByEnrollment
{
    class GetStudentByEnrollmentHandler : IRequestHandler<GetStudentByEnrollmentQuery, StudentDetailsViewModel>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<GetStudentByEnrollmentHandler> _logger;

        public GetStudentByEnrollmentHandler(IStudentRepository studentRepository, ILogger<GetStudentByEnrollmentHandler> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task<StudentDetailsViewModel> Handle(GetStudentByEnrollmentQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a consulta de Alunos pela matrícula = {request.Enrollment}");

            var student = await _studentRepository.GetByEnrollmentAsync(request.Enrollment);
            _logger.LogInformation($"Consultando os dados de todos os alunos e armazenando na variável Student={student}");

            if (student is null)
            {
                _logger.LogError("Erro na consulta");
                return null!;
            }

            var studentDetailsViewModel = new StudentDetailsViewModel(
                student.Enrollment,
                student.FullName!,
                student.Email!,
                student.BirthDate,
                student.CreatedAt,
                student.Active);

            _logger.LogInformation($"Detalhe do aluno que será exibido ={studentDetailsViewModel}");
            return studentDetailsViewModel;
        }
    }
}
