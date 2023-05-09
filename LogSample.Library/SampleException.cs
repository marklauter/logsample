using System.Runtime.Serialization;

namespace LogSample.Library
{
    public sealed class SampleException
        : Exception
    {
        public SampleException()
        {
        }

        public SampleException(string? message) : base(message)
        {
        }

        public SampleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SampleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}