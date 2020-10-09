using System;
using System.Net;

namespace Billing52Group.Client.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(HttpStatusCode code, string message)
            : base($"The request was reject with status code {(int)code}. Message: {message}")
        { }

        public BadRequestException(HttpStatusCode code)
            : base($"The request was reject with status code {(int)code}")
        { }
    }
}
