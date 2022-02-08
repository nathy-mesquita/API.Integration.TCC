using MediatR;

namespace API.Integration.TCC.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string? Content { get; set; }
        public int IdProjectTCC { get; set; }
        public int IdUser { get; set; }
    }
}
