using System;

namespace ExposureEvents.API
{
    public class ExposureApiException : Exception
    {
        public ExposureApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}