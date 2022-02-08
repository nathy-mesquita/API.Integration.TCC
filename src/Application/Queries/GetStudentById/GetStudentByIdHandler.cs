using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetStudentById
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetailsByIdViewModel>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<GetStudentByIdHandler> _logger;

        public GetStudentByIdHandler(IStudentRepository studentRepository, ILogger<GetStudentByIdHandler> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task<StudentDetailsByIdViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a consulta de Alunos pelo ID = {request.Id}");

            var student = await _studentRepository.GetByIdAsync(request.Id);
            _logger.LogInformation($"Consultando os dados de todos os alunos e armazenando na variável Student={student}");

            if (student is null)
            {
                _logger.LogError("Erro na consulta");
                return null!;
            }

            var studentDetailsViewModel = new StudentDetailsByIdViewModel(
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
