using MediatR;

namespace API.Integration.TCC.Application.Commands.LoginStudent
{
    public class LoginStudentCommand : IRequest<LoginStudentViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
