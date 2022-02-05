using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetTeacherById
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDetailsViewModel>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILogger<GetTeacherByIdHandler> _logger;

        public GetTeacherByIdHandler(ITeacherRepository teacherRepository, ILogger<GetTeacherByIdHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _logger = logger;
        }

        public async Task<TeacherDetailsViewModel> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a consulta de professores pelo Id= {request.Id}");

            var teacher = await _teacherRepository.GetByIdAsync(request.Id);
            _logger.LogInformation($"Consultando os dados de todos os professores e armazenando na variável teacher={teacher}");

            if (teacher is null)
            {
                _logger.LogError("Erro na consulta");
                return null!;
            }

            var studentDetailsViewModel = new TeacherDetailsViewModel(
                teacher.Id,
                teacher.FullName!,
                teacher.Email!,
                teacher.Specialty!,
                teacher.SubjectsTaught!,
                teacher.BirthDate,
                teacher.CreatedAt,
                teacher.Active);

            _logger.LogInformation($"Detalhe do professor que será exibido ={studentDetailsViewModel}");
            return studentDetailsViewModel;
        }
    }
}
