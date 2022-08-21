using System.Net;

namespace notes_api.Filters
{
    public class ApiPublicException : Exception
    {
        public string PublicMessage { get; }
        public HttpStatusCode StatusCode { get; }

        public ApiPublicException(HttpStatusCode statusCode, string publicMessage)
        {
            StatusCode = statusCode;
            PublicMessage = publicMessage;
        }
    }
}
