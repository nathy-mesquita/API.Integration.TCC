using MediatR;

namespace API.Integration.TCC.Application.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDetailsByIdViewModel>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
