using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.UpdateTeacherAdvisor
{
    public class UpdateTeacherAdvisorHandler : IRequestHandler<UpdateTeacherAdvisorCommand, Unit>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<UpdateTeacherAdvisorHandler> _logger;

        public UpdateTeacherAdvisorHandler(ITeacherRepository teacherRepository, IProjectTCCRepository projectTCCRepository, ILogger<UpdateTeacherAdvisorHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTeacherAdvisorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a atualização de um professor orientador de TCC!");

            _logger.LogInformation($"Buscando um projeto pelo ID={request.Id}");
            var projectTCC = await _projectTCCRepository.GetByIdAsync(request.Id);
            _logger.LogInformation($"Buscando um professor pelo ID={request.IdTeacher}");
            var teacherAdvisor = await _teacherRepository.GetByIdAsync(request.IdTeacher);
            if ((projectTCC is null) || (teacherAdvisor is null))
            {
                _logger.LogError($"O {nameof(projectTCC)} está {projectTCC}");
                _logger.LogError($"O {nameof(teacherAdvisor)} está {teacherAdvisor}");
                return Unit.Task.Result;
            }

            projectTCC.UpdateTeacher(projectTCC.IdTeacher);
            _logger.LogInformation($"Projeto de TCC com o IdTeacher atualizado");
            teacherAdvisor.UpdateTeacherAdvisor();
            _logger.LogInformation($"Professor {teacherAdvisor.FullName} se tornou um orientador do TCC {projectTCC.Title} do Aluno {projectTCC.Student!.FullName}.");

            await _projectTCCRepository.SaveChangesAsync();
            await _teacherRepository.SaveChangesAsync();
            _logger.LogInformation($"Projeto de TCC Salvo com sucesso!");

            return Unit.Value;
        }
    }
}
