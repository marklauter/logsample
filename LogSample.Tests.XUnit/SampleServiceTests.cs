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
            var id = Guid.NewGuid();
            this.sampleService.Succeed(new SampleData(id, nameof(Succeed_Succeeds), DateTime.UtcNow));

            var stdout = ((Xunit.Sdk.TestOutputHelper)this.output).Output;
            Assert.Contains("SampleData", stdout);
            Assert.Contains(id.ToString(), stdout);
        }
    }
}
