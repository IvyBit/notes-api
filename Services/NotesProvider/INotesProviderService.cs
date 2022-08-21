using notes_api.Data.Entities;

namespace notes_api.Services.NotesProvider
{
    public interface INotesProviderService
    {
        Task<Note> AddNote(Note note);

        Task<Note> UpdateNote(Note note);

        Task<Note> GetNote(int identity);

        Task<IEnumerable<Note>> GetNotes();

        Task<Note> DeleteNote(int identity);

    }
}
