using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Notes
{
    public class Details
    {
        public class Query : IRequest<Result<Note>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Note>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Note>> Handle(Query request, CancellationToken cancellationToken)
            {
                var note = await _context.Notes.FindAsync(request.Id);

                return Result<Note>.Success(note);
            }
        }
    }
}