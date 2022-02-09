using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.FinishProjectTCC
{
    [ExcludeFromCodeCoverage]
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
