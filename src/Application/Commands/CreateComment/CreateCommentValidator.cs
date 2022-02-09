using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.CreateComment
{
    [ExcludeFromCodeCoverage]
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250)
                .WithMessage("O conteúdo é obrigatório!");

            RuleFor(c => c.IdProjectTCC)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id do projeto é obrigatório!");

            RuleFor(c => c.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id do usuário é obrigatório");
        }
    }
}
