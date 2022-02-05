using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetAllProjectTCC
{
    public class GetAllProjectTCCHandler : IRequestHandler<GetAllProjectTCCQuery, List<ProjectTCCViewModel>>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<GetAllProjectTCCHandler> _logger;

        public GetAllProjectTCCHandler(IProjectTCCRepository projectTCCRepository, ILogger<GetAllProjectTCCHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<List<ProjectTCCViewModel>> Handle(GetAllProjectTCCQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a consulta de projetos");

            var projectsTCC = await _projectTCCRepository.GetAllAsync();
            _logger.LogInformation($"Consultando os dados de todos os projetos e armazenando na variável projectsTCC={projectsTCC}");

            var projectTCCViewModel = projectsTCC
            .Select(p => new ProjectTCCViewModel(p.Id, p.Title!, p.Description!, p.DefenseForecast))
            .ToList();
            _logger.LogInformation($"Lista de todos os projetos que serão exibidos projectTCCViewModel={projectTCCViewModel}");

            return projectTCCViewModel;
        }
    }
}
