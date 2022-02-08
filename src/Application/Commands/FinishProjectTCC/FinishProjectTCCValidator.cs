using FluentValidation;

namespace API.Integration.TCC.Application.Commands.FinishProjectTCC
{
    public class FinishProjectTCCValidator : AbstractValidator<FinishProjectTCCCommand>
    {
        public FinishProjectTCCValidator()
        {
            RuleFor(d => d.Id)
               .NotEmpty()
               .NotNull()
               .WithMessage("O Id é obrigatório!");
        }
    }
}
