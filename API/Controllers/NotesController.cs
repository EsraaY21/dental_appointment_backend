using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class NotesController : BaseApiController
    {
        private readonly DataContext _context;
        public NotesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //api/notes
        public async Task<ActionResult<List<Note>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        [HttpGet("{id}")] //api/notes/fdfkdffdfd
        public async Task<ActionResult<Note>> GetNote(Guid id)
        {
            return await _context.Notes.FindAsync(id);
        }
    }
}