using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.StartProjectTCC
{
    public class StartProjectTCCHandler : IRequestHandler<StartProjectTCCCommand, Unit>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<StartProjectTCCHandler> _logger;

        public StartProjectTCCHandler(IProjectTCCRepository projectTCCRepository, ILogger<StartProjectTCCHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(StartProjectTCCCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Startando um projeto de TCC!");

            _logger.LogInformation($"Buscando um projeto pelo ID={request.Id}");
            var projectTCC = await _projectTCCRepository.GetByIdAsync(request.Id);
            if (projectTCC is null)
            {
                _logger.LogInformation($"O {nameof(projectTCC)} está {projectTCC}");
                return Unit.Task.Result;
            }
            projectTCC.Start();
            _logger.LogInformation($"Projeto de TCC startado");

            await _projectTCCRepository.SaveChangesAsync();
            _logger.LogInformation($"O status do projeto é em progresso!");

            return Unit.Value;
        }
    }
}
