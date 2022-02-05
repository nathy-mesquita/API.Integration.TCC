using MediatR;
using System;

namespace API.Integration.TCC.Application.Queries.GetStudentByEnrollment
{
    public class GetStudentByEnrollmentQuery : IRequest<StudentDetailsViewModel>
    {
        public GetStudentByEnrollmentQuery(Guid enrollment)
        {
            Enrollment = enrollment;
        }

        public Guid Enrollment { get; private set; }
    }
}
