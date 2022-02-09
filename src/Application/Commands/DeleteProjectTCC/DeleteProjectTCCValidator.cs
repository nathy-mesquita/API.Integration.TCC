using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.DeleteProjectTCC
{
    [ExcludeFromCodeCoverage]
    public class DeleteProjectTCCValidator : AbstractValidator<DeleteProjectTCCCommand>
    {
        public DeleteProjectTCCValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id é obrigatório!");
        }
    }
}
