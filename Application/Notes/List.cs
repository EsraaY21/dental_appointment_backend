using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Notes
{
    public class List
    {
        public class Query : IRequest<Result<List<Note>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Note>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Note>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Note>>.Success(await _context.Notes.ToListAsync());
            }
        }
    }
}