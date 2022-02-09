using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.StartProjectTCC
{
    [ExcludeFromCodeCoverage]
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
