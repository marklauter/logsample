using System.Runtime.Serialization;

namespace LogSample.Library
{
    public sealed class SampleOuterException
        : Exception
    {
        public SampleOuterException()
        {
        }

        public SampleOuterException(string? message) : base(message)
        {
        }

        public SampleOuterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SampleOuterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
