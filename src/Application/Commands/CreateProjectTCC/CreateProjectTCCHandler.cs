using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.CreateProjectTCC
{
    public class CreateProjectTCCHandler : IRequestHandler<CreateProjectTCCCommand, int>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<CreateProjectTCCHandler> _logger;

        public CreateProjectTCCHandler(IProjectTCCRepository projectTCCRepository, ILogger<CreateProjectTCCHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProjectTCCCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando a criação de um projeto de TCC");
            var projectTCC = new ProjectTCC(request.Title, request.Description, request.IdStudent, request.DefenseForecast);
            await _projectTCCRepository.AddAsync(projectTCC);
            _logger.LogInformation($"Projeto de TCC criado projectTCC= {projectTCC}");
            return projectTCC.Id;
        }
    }
}
