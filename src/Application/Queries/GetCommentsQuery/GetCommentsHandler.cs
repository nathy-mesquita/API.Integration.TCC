using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Queries.GetCommentsQuery
{
    public class GetCommentsHandler : IRequestHandler<GetCommentsQuery, List<CommentsViewModel>>
    {
        private readonly IProjectTCCCommentsRepository _projectTCCCommentsRepository;
        private readonly ILogger<GetCommentsHandler> _logger;

        public GetCommentsHandler(IProjectTCCCommentsRepository projectTCCCommentsRepository, ILogger<GetCommentsHandler> logger)
        {
            _projectTCCCommentsRepository = projectTCCCommentsRepository;
            _logger = logger;
        }

        public async Task<List<CommentsViewModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Iniciando a busca de um comentário de um projeto");

            var comments = await _projectTCCCommentsRepository.GetAsyncByProjectTCC(request.Id);
            _logger.LogInformation($"Comentário do projeto consultado o retorno está na variável comments={comments}");

            if (comments is null)
            {
                _logger.LogError("Erro ao buscar um comentário!");
                return null!;
            }
            //TODO: Como exibir um comentário de um projeto com o Id e o nome do usuário independente do tipo.
            var commentsViewModel = comments
                .Select(c => new CommentsViewModel(c.IdProjectTCC, c.Content, c.CreatedAt, c.Student!.FullName, c.Student.Id))
                .OrderBy(c => c.CreatedAt)
                .ToList();
            _logger.LogInformation($"Lista de todos os comentários do projeto serão exibidos commentsViewModel={commentsViewModel}");

            return commentsViewModel;
        }
    }
}
