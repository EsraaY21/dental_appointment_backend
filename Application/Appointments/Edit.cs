using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Appointments
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Appointment Appointment { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Appointment).SetValidator(new AppointmentValidator());
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
                var appointmentAppointment = await _context.Appointments.FindAsync(request.Appointment.Id);

                if (appointmentAppointment == null) return null;

                _mapper.Map(request.Appointment, appointmentAppointment);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update appointmentAppointment");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}