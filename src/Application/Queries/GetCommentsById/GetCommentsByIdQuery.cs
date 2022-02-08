using MediatR;

namespace API.Integration.TCC.Application.Queries.GetCommentsById
{
    public class GetCommentsByIdQuery : IRequest<CommentsDetailsViewModel>
    {
        public GetCommentsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
