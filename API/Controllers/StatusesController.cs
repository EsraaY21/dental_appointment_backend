using Application.Statuses;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatusesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Status>>> GetStatuses()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatus(Status status)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Status = status }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Status status)
        {
            status.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Status = status }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}