using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace API.Integration.TCC.Application.Commands.CreateTeacher
{
    public class CreateTeacherValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherValidator()
        {
            RuleFor(t => t.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");

            RuleFor(t => t.Email)
                .EmailAddress()
                .WithMessage("Email inválido!");

            RuleFor(s => s.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter no mínimo 8 dígitos, uma letra maiúscula, uma minúscula e um caractere especial!");

            RuleFor(t => t.BirthDate)
               .NotEmpty().WithMessage("Data de nascimento obrigatória!")
               .LessThan(p => DateTime.Now).WithMessage("A data deve estar no passado!");

            RuleFor(t => t.Specialty)
                .NotNull()
                .NotEmpty()
                .WithMessage("A especialidade é obrigatória!");

            RuleFor(t => t.SubjectsTaught)
                .NotNull()
                .NotEmpty()
                .WithMessage("A disciplina é obrigatória!");

        }

        public bool ValidPassword(string? password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password!);
        }
    }
}
