using MediatR;
using System.Collections.Generic;

namespace API.Integration.TCC.Application.Queries.GetCommentsQuery
{
    public class GetCommentsQuery : IRequest<List<CommentsViewModel>>
    {
        public GetCommentsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
