using API.Integration.TCC.Application.Models.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace API.Integration.TCC.Application.Queries.GetAllStudent
{
    public class GetAllStudentQuery : IRequest<List<StudentViewModel>>
    {
        public GetAllStudentQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
