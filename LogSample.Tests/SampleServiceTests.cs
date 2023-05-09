using LogSample.Library;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using Xunit.Abstractions;

namespace LogSample.Tests.Serilog
{
    public sealed class SampleServiceTests
    {
        private readonly ITestOutputHelper output;
        private readonly ISampleService sampleService;

        public SampleServiceTests(
            IServiceProvider serviceProvider,
            ITestOutputHelper output)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            this.output = output ?? throw new ArgumentNullException(nameof(output));
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.TestOutput(output, new CompactJsonFormatter())
                .CreateLogger();

            this.sampleService = serviceProvider.GetRequiredService<ISampleService>();
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
