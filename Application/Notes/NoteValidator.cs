using Domain;
using FluentValidation;

namespace Application.Notes
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}