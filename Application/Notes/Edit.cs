using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Notes
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Note Note { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Note).SetValidator(new NoteValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var noteNote = await _context.Notes.FindAsync(request.Note.Id);

                if (noteNote == null) return null;

                _mapper.Map(request.Note, noteNote);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update noteNote");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}