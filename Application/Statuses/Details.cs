using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Statuses
{
    public class Details
    {
        public class Query : IRequest<Result<Status>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Status>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Status>> Handle(Query request, CancellationToken cancellationToken)
            {
                var status = await _context.Statuses.FindAsync(request.Id);

                return Result<Status>.Success(status);
            }
        }
    }
}