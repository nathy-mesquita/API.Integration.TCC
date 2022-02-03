namespace API.Integration.TCC.Application.Commands.LoginTeacher
{
    public class LoginTeacherViewModel
    {
        public LoginTeacherViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
