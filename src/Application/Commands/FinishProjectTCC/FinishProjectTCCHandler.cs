using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.FinishProjectTCC
{
    public class FinishProjectTCCHandler : IRequestHandler<FinishProjectTCCCommand, Unit>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<FinishProjectTCCHandler> _logger;

        public FinishProjectTCCHandler(IProjectTCCRepository projectTCCRepository, ILogger<FinishProjectTCCHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(FinishProjectTCCCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a finalização de um projeto de TCC!");

            _logger.LogInformation($"Buscando um projeto pelo ID={request.Id}");
            var projectTCC = await _projectTCCRepository.GetByIdAsync(request.Id);

            projectTCC.Finish();
            _logger.LogInformation($"Projeto de TCC finalizado!");

            await _projectTCCRepository.SaveChangesAsync();
            _logger.LogInformation($"O status do projeto é finalizado!");

            return Unit.Value;
        }
    }
}
