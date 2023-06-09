using Application.Appointments;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class AppointmentsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAppointments()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Appointment appointment)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Appointment = appointment }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Appointment appointment)
        {
            appointment.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Appointment = appointment }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}