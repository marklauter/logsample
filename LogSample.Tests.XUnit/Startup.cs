using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDISP004 // Don't ignore created IDisposable

namespace LogSample.Tests.XUnit
{
    public sealed class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services
                .AddLogging()
                .AddSampleService();
        }

        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
            loggerFactory.AddProvider(
                new XunitTestOutputLoggerProvider(
                    accessor,
                    (source, ll) => ll >= LogLevel.Trace));
        }
    }
}

#pragma warning restore IDISP004 // Don't ignore created IDisposable
#pragma warning restore CA1822 // Mark members as static
