using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetCommentsById
{
    public class GetCommentsByIdHandler : IRequestHandler<GetCommentsByIdQuery, CommentsDetailsViewModel>
    {
        private readonly IProjectTCCCommentsRepository _projectTCCCommentsRepository;
        private readonly ILogger<GetCommentsByIdHandler> _logger;

        public GetCommentsByIdHandler(IProjectTCCCommentsRepository projectTCCCommentsRepository, ILogger<GetCommentsByIdHandler> logger)
        {
            _projectTCCCommentsRepository = projectTCCCommentsRepository;
            _logger = logger;
        }

        public async Task<CommentsDetailsViewModel> Handle(GetCommentsByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a busca de um comentário");

            var comment = await _projectTCCCommentsRepository.GetDetailsByIdAsync(request.Id);
            _logger.LogInformation($"O comentário consultado o retorno está na variável comment={comment}");

            if (comment is null)
            {
                _logger.LogError("Erro ao buscar um comentário!");
                return null!;
            }
            //TODO: Como exibir um comentário de um projeto com o Id e o nome do usuário independente do tipo.
            var commentsDetailsViewModel = new CommentsDetailsViewModel(comment.Id, comment.IdProjectTCC, comment.Content, comment.CreatedAt, comment.IdUser);
            _logger.LogInformation($"O comentário do projeto de tcc que será exibido commentsDetailsViewModel={commentsDetailsViewModel}");

            return commentsDetailsViewModel;
        }
    }
}
