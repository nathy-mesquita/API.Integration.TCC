using FluentValidation;

namespace API.Integration.TCC.Application.Commands.UpdateTeacherAdvisor
{
    public class UpdateTeacherAdvisorValidator : AbstractValidator<UpdateTeacherAdvisorCommand>
    {
        public UpdateTeacherAdvisorValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage($"O Id do projeto é obrigatório!");

            RuleFor(p => p.IdTeacher)
                .NotEmpty()
                .NotNull()
                .WithMessage($"O Id do professor é obrigatório!");
        }
    }
}
