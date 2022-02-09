using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.CreateProjectTCC
{
    [ExcludeFromCodeCoverage]
    public class CreateProjectTCCValidator : AbstractValidator<CreateProjectTCCCommand>
    {
        public CreateProjectTCCValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage($"O titulo é obrigatório!");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .Length(1, 250)
                .WithMessage($"A descrição é obrigatória!");

            RuleFor(p => p.IdStudent)
                .NotEmpty()
                .NotNull()
                .WithMessage($"O id do aluno é obrigatório!");

            RuleFor(p => p.DefenseForecast)
                .NotEmpty()
                .NotNull()
                .WithMessage($"A data da defesa é obrigatória!");
        }
    }
}
