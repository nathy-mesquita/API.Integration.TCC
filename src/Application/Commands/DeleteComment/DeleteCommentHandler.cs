using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly IProjectTCCCommentsRepository _projectTCCCommentsRepository;
        private readonly ILogger<DeleteCommentHandler> _logger;

        public DeleteCommentHandler(IProjectTCCCommentsRepository projectTCCCommentsRepository, ILogger<DeleteCommentHandler> logger)
        {
            _projectTCCCommentsRepository = projectTCCCommentsRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a deleção de um projeto de TCC!");

            _logger.LogInformation($"Buscando um projeto pelo ID={request.Id}");
            var projectTCC = await _projectTCCCommentsRepository.GetDetailsByIdAsync(request.Id);

            projectTCC.Delete();
            _logger.LogInformation($"Projeto de TCC deletado!");

            await _projectTCCCommentsRepository.SaveChangesAsync();
            _logger.LogInformation($"O status do projeto é deletado!");

            return Unit.Value;
        }
    }
}
