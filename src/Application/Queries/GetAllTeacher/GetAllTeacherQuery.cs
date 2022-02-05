using MediatR;
using System.Collections.Generic;

namespace API.Integration.TCC.Application.Queries.GetAllTeacher
{
    public class GetAllTeacherQuery : IRequest<List<TeacherViewModel>>
    {
        public GetAllTeacherQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
