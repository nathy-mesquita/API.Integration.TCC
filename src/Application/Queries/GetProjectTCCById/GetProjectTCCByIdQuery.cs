using MediatR;

namespace API.Integration.TCC.Application.Queries.GetProjectTCCById
{
    public class GetProjectTCCByIdQuery : IRequest<ProjectTCCDetailsViewModel>
    {
        public GetProjectTCCByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
