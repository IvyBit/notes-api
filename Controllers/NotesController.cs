using Microsoft.AspNetCore.Mvc;
using notes_api.Data.Entities;
using notes_api.Services.NotesProvider;

namespace notes_api.Controllers
{
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesProviderService _notesProvider;
        public NotesController(INotesProviderService notesProvider)
        {
            _notesProvider = notesProvider;
        }


        [HttpGet("{noteId:int}")]
        public async Task<Note> Get(int noteId)
        {
            return await _notesProvider.GetNoteAsync(noteId);
        }

        [HttpGet()]
        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _notesProvider.GetNotesAsync();
        }

        [HttpPost]
        public async Task<Note> Post(Note note)
        {
            return await _notesProvider.AddNoteAsync(note);
        }

        [HttpPatch]
        public async Task<Note> Patch(Note note)
        {
            return await _notesProvider.UpdateNoteAsync(note);
        }

        [HttpDelete("{noteId:int}")]
        public async Task<Note> Delete(int noteId)
        {
            return await _notesProvider.DeleteNoteAsync(noteId);
        }
    }
}
