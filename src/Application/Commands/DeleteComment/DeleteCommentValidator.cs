using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.DeleteComment
{
    [ExcludeFromCodeCoverage]
    public class DeleteCommentValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id é obrigatório!");
        }
    }
}
