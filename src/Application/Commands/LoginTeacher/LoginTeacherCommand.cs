using MediatR;

namespace API.Integration.TCC.Application.Commands.LoginTeacher
{
    public class LoginTeacherCommand : IRequest<LoginTeacherViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
