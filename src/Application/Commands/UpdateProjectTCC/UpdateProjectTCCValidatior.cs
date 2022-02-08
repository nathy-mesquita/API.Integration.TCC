using FluentValidation;

namespace API.Integration.TCC.Application.Commands.UpdateProjectTCC
{
    public class UpdateProjectTCCValidatior : AbstractValidator<UpdateProjectTCCCommand>
    {
        public UpdateProjectTCCValidatior()
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

            RuleFor(p => p.DefenseForecast)
                .NotEmpty()
                .NotNull()
                .WithMessage($"A data da defesa é obrigatória!");
        }

    }
}
