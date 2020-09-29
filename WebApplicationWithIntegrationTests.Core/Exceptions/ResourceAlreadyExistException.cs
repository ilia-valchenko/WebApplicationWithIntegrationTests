using System;

namespace WebApplicationWithIntegrationTests.Core.Exceptions
{
    public class ResourceAlreadyExistException : Exception
    {
        public ResourceAlreadyExistException()
        {
        }

        public ResourceAlreadyExistException(string message) : base(message)
        {
        }

        public ResourceAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}