using MediatR;
using System;

namespace API.Integration.TCC.Application.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Course { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
