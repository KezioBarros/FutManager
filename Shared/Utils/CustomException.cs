using System.Net;

namespace Shared.Utils
{
    public class CustomException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public CustomException(string message, HttpStatusCode httpStatusCode)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
