namespace Munix.Miniflux
{
    using System;
    using System.Net;

    [System.Serializable]
    public class MinifluxException : Exception
    {
        public MinifluxException()
        {
        }

        public MinifluxException(string message)
            : base(message)
        {
        }

        public MinifluxException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MinifluxException(
            HttpStatusCode statusCode,
            string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public MinifluxException(
            HttpStatusCode statusCode,
            string message,
            Exception inner)
            : base(message, inner)
        {
            this.StatusCode = statusCode;
        }

        protected MinifluxException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        public HttpStatusCode StatusCode { get; }
    }
}
