using FluentValidation;

namespace API.Integration.TCC.Application.Commands.DeleteProjectTCC
{
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
