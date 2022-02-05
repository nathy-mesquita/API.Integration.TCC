using MediatR;

namespace API.Integration.TCC.Application.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery : IRequest<TeacherDetailsViewModel>
    {
        public GetTeacherByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
