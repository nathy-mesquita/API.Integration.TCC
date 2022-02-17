using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.UpdateProjectTCC
{
    public class UpdateProjectTCCHandler : IRequestHandler<UpdateProjectTCCCommand, Unit>
    {
        private readonly IProjectTCCRepository _projectTCCRepository;
        private readonly ILogger<UpdateProjectTCCHandler> _logger;

        public UpdateProjectTCCHandler(IProjectTCCRepository projectTCCRepository, ILogger<UpdateProjectTCCHandler> logger)
        {
            _projectTCCRepository = projectTCCRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProjectTCCCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a atualização de um projeto de TCC!");

            _logger.LogInformation($"Buscando um projeto pelo ID={request.Id}");
            var projectTCC = await _projectTCCRepository.GetByIdAsync(request.Id);
            if (projectTCC is null)
            {
                _logger.LogError($"O {nameof(projectTCC)} está {projectTCC}");
                return Unit.Task.Result;
            }
            projectTCC.Update(projectTCC.Title!, projectTCC.Description!, projectTCC.DefenseForecast);
            _logger.LogInformation($"Projeto de TCC atualizado");

            await _projectTCCRepository.SaveChangesAsync();
            _logger.LogInformation($"Projeto de TCC Salvo com sucesso!");

            return Unit.Value;
        }
    }
}
