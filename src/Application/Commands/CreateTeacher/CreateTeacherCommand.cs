using MediatR;
using System;

namespace API.Integration.TCC.Application.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Specialty { get; set; }
        public string? SubjectsTaught { get; set; }
    }
}
