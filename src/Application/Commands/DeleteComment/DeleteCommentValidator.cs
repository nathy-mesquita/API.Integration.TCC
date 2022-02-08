using FluentValidation;

namespace API.Integration.TCC.Application.Commands.DeleteComment
{
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
