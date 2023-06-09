using Domain;
using FluentValidation;

namespace Application.Appointments
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Patient).NotEmpty();
            RuleFor(x => x.Doctor).NotEmpty();
            RuleFor(x => x.Service).NotEmpty();
            RuleFor(x => x.Day).NotEmpty();
        }
    }
}