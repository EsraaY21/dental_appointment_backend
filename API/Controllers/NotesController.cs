using Application.Notes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class NotesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetNotes()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(Note note)
        {
            return Ok(await Mediator.Send(new Create.Command { Note = note }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Note note)
        {
            note.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Note = note }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}