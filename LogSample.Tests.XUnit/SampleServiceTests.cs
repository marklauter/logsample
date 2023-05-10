using Xunit.Abstractions;

namespace LogSample.Tests.XUnit
{
    public sealed class SampleServiceTests
    {
        private readonly ITestOutputHelper output;
        private readonly ISampleService sampleService;

        public SampleServiceTests(
            ISampleService sampleService,
            ITestOutputHelper output)
        {
            this.sampleService = sampleService ?? throw new ArgumentNullException(nameof(sampleService));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
        }

        [Fact]
        public void Succeed_Succeeds()
        {
            var sampleData = new SampleData(
                Guid.NewGuid(),
                nameof(Succeed_Succeeds),
                DateTime.UtcNow);
            this.sampleService.Succeed(sampleData);

            var stdout = ((Xunit.Sdk.TestOutputHelper)this.output).Output;
            Assert.Contains("SampleData", stdout);
            Assert.Contains(sampleData.Id.ToString(), stdout);
        }
    }
}
