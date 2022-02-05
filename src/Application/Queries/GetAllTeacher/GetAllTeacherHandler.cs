using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetAllTeacher
{
    public class GetAllTeacherHandler : IRequestHandler<GetAllTeacherQuery, List<TeacherViewModel>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILogger<GetAllTeacherHandler> _logger;

        public GetAllTeacherHandler(ITeacherRepository teacherRepository, ILogger<GetAllTeacherHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _logger = logger;
        }

        public async Task<List<TeacherViewModel>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a consulta de Professores");
            var teachers = await _teacherRepository.GetAllAsync();
            _logger.LogInformation($"Consultando os dados de todos os professores e armazenando na variável teacher={teachers}");

            var teacherViewModel = teachers
            .Select(t => new TeacherViewModel(t.Id, t.FullName!, t.Email!, t.SubjectsTaught!, t.CreatedAt))
            .ToList();
            _logger.LogInformation($"Lista de todos os professores que serão exibidos teachers={teacherViewModel}");

            return teacherViewModel;
        }
    }
}
