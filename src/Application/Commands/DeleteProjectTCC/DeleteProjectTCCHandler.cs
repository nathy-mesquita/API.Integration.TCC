using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.DeleteProjectTCC
{
    public class DeleteProjectTCCHandler : IRequestHandler<DeleteProjectTCCCommand, Unit>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<DeleteProjectTCCHandler> _logger;

        public DeleteProjectTCCHandler(IProjectTCCRepository projectTCCRepository, ILogger<DeleteProjectTCCHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProjectTCCCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a deleção de um projeto de TCC!");

            _logger.LogInformation($"Buscando um projeto pelo ID={request.Id}");
            var projectTCC = await _projectTCCRepository.GetByIdAsync(request.Id);

            projectTCC.Cancel();
            _logger.LogInformation($"Projeto de TCC deletado!");

            await _projectTCCRepository.SaveChangesAsync();
            _logger.LogInformation($"O status do projeto é cancelado!");

            return Unit.Value;
        }
    }
}
