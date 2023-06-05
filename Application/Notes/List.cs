using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Notes
{
    public class List
    {
        public class Query : IRequest<List<Note>> { }

        public class Handler : IRequestHandler<Query, List<Note>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Note>> Handle(Query request, CancellationToken token)
            {
                return await _context.Notes.ToListAsync();
            }
        }
    }
}