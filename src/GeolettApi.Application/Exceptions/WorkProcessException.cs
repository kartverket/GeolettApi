using System;

namespace GeolettApi.Application.Exceptions
{
    public class WorkProcessException : Exception
    {
        public WorkProcessException()
        {
        }

        public WorkProcessException(string message) : base(message)
        {
        }

        public WorkProcessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
