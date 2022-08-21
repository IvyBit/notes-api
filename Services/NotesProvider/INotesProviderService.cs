using notes_api.Data.Entities;

namespace notes_api.Services.NotesProvider
{
    public interface INotesProviderService
    {
        Task<Note> AddNoteAsync(Note note);

        Task<Note> UpdateNoteAsync(Note note);

        Task<Note> GetNoteAsync(int identity);

        Task<IEnumerable<Note>> GetNotesAsync();

        Task<Note> DeleteNoteAsync(int identity);

    }
}
