using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IProjectTCCCommentsRepository _projectTCCCommentsRepository;
        private readonly ILogger<UpdateCommentHandler> _logger;

        public UpdateCommentHandler(IProjectTCCCommentsRepository projectTCCCommentsRepository, ILogger<UpdateCommentHandler> logger)
        {
            _projectTCCCommentsRepository = projectTCCCommentsRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a atualização de um comentário!");

            _logger.LogInformation($"Buscando um comentário pelo ID={request.Id}");
            var comment = await _projectTCCCommentsRepository.GetDetailsByIdAsync(request.Id);

            comment.Update(comment.Content!);
            _logger.LogInformation($"Comentário atualizado!");

            await _projectTCCCommentsRepository.SaveChangesAsync();
            _logger.LogInformation($"Comentário salvo com sucesso!");

            return Unit.Value;
        }
    }
}
