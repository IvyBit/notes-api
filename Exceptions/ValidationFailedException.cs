using notes_api.Filters;

namespace notes_api.Services.NotesProvider
{
    public class ValidationFailedException : ApiPublicException
    {
        public ValidationFailedException(params string[] properties)
            : base(System.Net.HttpStatusCode.BadRequest, $"Invalid values: '{string.Join(',',properties)}'")
        {}

    }
}
