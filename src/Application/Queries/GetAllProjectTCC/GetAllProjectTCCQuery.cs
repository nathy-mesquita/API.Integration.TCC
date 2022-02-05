using MediatR;
using System.Collections.Generic;

namespace API.Integration.TCC.Application.Queries.GetAllProjectTCC
{
    public class GetAllProjectTCCQuery : IRequest<List<ProjectTCCViewModel>>
    {
        public GetAllProjectTCCQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
