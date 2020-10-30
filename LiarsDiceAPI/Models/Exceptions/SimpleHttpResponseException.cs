using System;
using System.Net;

namespace LiarsDiceAPI.Models.Exceptions
{
    public class GameException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public GameException(HttpStatusCode statusCode, string messageContent) 
            : base(messageContent)
        {
            StatusCode = statusCode;
        }
    }

    public class SimpleHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public SimpleHttpResponseException(HttpStatusCode statusCode, string messageContent) 
            : base(messageContent)
        {
            StatusCode = statusCode;
        }
    }
}
