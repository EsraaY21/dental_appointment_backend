using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Statuses
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Status Status { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Status).SetValidator(new StatusValidator());
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
                var status = await _context.Statuses.Where(x => x.Id == request.Status.Id).FirstOrDefaultAsync();

                if (status == null) return null;

                _mapper.Map(request.Status, status);

                var f = _context.Statuses.Update(status);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update status");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}