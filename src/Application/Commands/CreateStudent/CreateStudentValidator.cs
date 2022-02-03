using FluentValidation;
using System.Text.RegularExpressions;

namespace API.Integration.TCC.Application.Commands.CreateStudent
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(s => s.Email)
                .EmailAddress()
                .WithMessage("Email inválido!");

            RuleFor(s => s.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter no mínimo 8 dígitos, uma letra maiúscula, uma minúscula e um caractere especial!");

            RuleFor(s => s.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");

            RuleFor(s => s.Course)
                .NotNull()
                .NotEmpty()
                .WithMessage("O curso é obrigatório!");

            RuleFor(s => s.BirthDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("A data de nascimento é obrigatória!");


        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}
