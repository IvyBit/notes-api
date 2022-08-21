using notes_api.Filters;

namespace notes_api.Services.NotesProvider
{
    public class NoteNotFoundException : ApiPublicException
    {
        public NoteNotFoundException()
            : base(System.Net.HttpStatusCode.BadRequest,"Unknown note")
        {}

    }
}
