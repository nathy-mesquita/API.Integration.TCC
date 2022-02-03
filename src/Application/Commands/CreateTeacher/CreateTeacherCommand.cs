using MediatR;
using System;

namespace API.Integration.TCC.Application.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Specialty { get; private set; }
        public string SubjectsTaught { get; private set; }
    }
}
