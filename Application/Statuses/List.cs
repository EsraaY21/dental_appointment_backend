using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Statuses
{
    public class List
    {
        public class Query : IRequest<Result<List<Status>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Status>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Status>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Status>>.Success(await _context.Statuses.ToListAsync());
            }
        }
    }
}