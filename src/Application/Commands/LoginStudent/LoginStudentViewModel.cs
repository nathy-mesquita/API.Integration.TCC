namespace API.Integration.TCC.Application.Commands.LoginStudent
{
    public class LoginStudentViewModel
    {
        public LoginStudentViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
