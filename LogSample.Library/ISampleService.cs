namespace LogSample.Library
{
    public interface ISampleService
    {
        void Succeed(SampleData data);
        void Fail(SampleData data);
    }
}
