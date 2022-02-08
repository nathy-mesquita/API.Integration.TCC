using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace API.Integration.TCC.Application.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IProjectTCCCommentsRepository _projectTCCCommentsRepository;
        private readonly ILogger<CreateCommentHandler> _logger;

        public CreateCommentHandler(IProjectTCCCommentsRepository projectTCCCommentsRepository, ILogger<CreateCommentHandler> logger)
        {
            _projectTCCCommentsRepository = projectTCCCommentsRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            //TODO: Como criar um comentário de um projeto independente do tipo de usuário.
            _logger.LogInformation("Iniciando a criação de um comentário no projeto");
            var comment = new ProjectTCCComments(request.Content, request.IdProjectTCC, request.IdUser);
            await _projectTCCCommentsRepository.AddCommentAsync(comment);
            _logger.LogInformation($"Comentário de projeto de TCC criado comment= {comment}");
            return comment.Id;
        }
    }
}
