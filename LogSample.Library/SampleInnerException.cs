using System.Runtime.Serialization;

namespace LogSample.Library
{
    public sealed class SampleInnerException
    : Exception
    {
        public SampleInnerException()
        {
        }

        public SampleInnerException(string? message) : base(message)
        {
        }

        public SampleInnerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SampleInnerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
