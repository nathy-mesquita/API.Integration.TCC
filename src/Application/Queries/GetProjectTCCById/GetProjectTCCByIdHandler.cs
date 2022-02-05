using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetProjectTCCById
{
    public class GetProjectTCCByIdHandler : IRequestHandler<GetProjectTCCByIdQuery, ProjectTCCDetailsViewModel>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<GetProjectTCCByIdHandler> _logger;

        public GetProjectTCCByIdHandler(IProjectTCCRepository projectTCCRepository, ILogger<GetProjectTCCByIdHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<ProjectTCCDetailsViewModel> Handle(GetProjectTCCByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a busca de um projeto");

            var projectTCC = await _projectTCCRepository.GetDetailsByIdAsync(request.Id);
            _logger.LogInformation($"Projeto consultado o retorno está na variável projectTCC={projectTCC}");

            if (projectTCC is null)
            {
                _logger.LogError("Erro ao buscar um projeto!");
                return null!;
            }

            var projectTCCDetailsViewModel = new ProjectTCCDetailsViewModel(
                projectTCC.Id,
                projectTCC.Title!,
                projectTCC.Description!,
                projectTCC.Student!.Enrollment,
                projectTCC.Student.FullName!,
                projectTCC.DefenseForecast,
                projectTCC.Status,
                projectTCC.CreatedAt,
                projectTCC.StartedAt,
                projectTCC.FinishedAt);
            _logger.LogInformation($"O detalhe do projeto de tcc que será exibido projectTCCDetailsViewModel={projectTCCDetailsViewModel}");

            return projectTCCDetailsViewModel;
        }
    }
}
