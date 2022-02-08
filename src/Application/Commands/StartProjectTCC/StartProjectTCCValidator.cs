using FluentValidation;

namespace API.Integration.TCC.Application.Commands.StartProjectTCC
{
    public class StartProjectTCCValidator : AbstractValidator<StartProjectTCCCommand>
    {
        public StartProjectTCCValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id é obrigatório!");
        }
    }
}
