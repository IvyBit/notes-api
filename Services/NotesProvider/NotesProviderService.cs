using Microsoft.EntityFrameworkCore;
using notes_api.Data.Context;
using notes_api.Data.Entities;

namespace notes_api.Services.NotesProvider
{
    public class NotesProviderService : INotesProviderService
    {
        private readonly InMemoryDbContext _context;


        public NotesProviderService(InMemoryDbContext context)
        {
            _context = context;
        }


        public async Task<Note> AddNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note> DeleteNote(int identity)
        {
            var note = await _context.Notes.FindAsync(identity);
            if(note != null)
            {
                _context.Notes.Remove(note);
                return note;
            }
            throw new Exception("Unknown entity");
        }

        public async Task<Note> GetNote(int identity)
        {
            var note = await _context.Notes.FindAsync(identity);
            if(note != null)
            {
                return note;
            }
            throw new Exception("Unknown entity");
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _context.Notes.OrderBy(e => e.TimeStamp).ToListAsync();
        }

        public async Task<Note> UpdateNote(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }
    }
}
