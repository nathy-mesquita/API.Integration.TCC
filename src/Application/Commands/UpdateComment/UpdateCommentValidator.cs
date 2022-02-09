using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Application.Commands.UpdateComment
{
    [ExcludeFromCodeCoverage]
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(c => c.Content)
               .NotEmpty()
               .NotNull()
               .Length(1, 250)
               .WithMessage($"O conteúdo é obrigatório!");
        }
    }
}
