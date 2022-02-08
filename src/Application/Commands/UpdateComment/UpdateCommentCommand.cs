using MediatR;

namespace API.Integration.TCC.Application.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        /// <summary>
        /// Identificador do comentário
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Conteudo
        /// </summary>
        public string? Content { get; set; }
    }
}
