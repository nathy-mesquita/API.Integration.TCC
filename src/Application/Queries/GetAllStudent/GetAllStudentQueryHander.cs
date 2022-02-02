using API.Integration.TCC.Application.Models.ViewModels;
using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetAllStudent
{
    public class GetAllStudentQueryHander : IRequestHandler<GetAllStudentQuery, List<StudentViewModel>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<GetAllStudentQueryHander> _logger;

        public GetAllStudentQueryHander(IStudentRepository studentRepository, ILogger<GetAllStudentQueryHander> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task<List<StudentViewModel>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a consulta de Alunos");
            var students = await _studentRepository.GetAllAsync();
            _logger.LogInformation($"Consultando os dados de todos os alunos e armazenando na variável ={students}");

            var userViewModel = students
            .Select(s => new StudentViewModel(s.Enrollment, s.FullName, s.Email, s.Role, s.CreatedAt))
            .ToList();
            _logger.LogInformation($"Lista de todos os alunos que serão exibidos ={userViewModel}");

            return userViewModel;
        }
    }
}
