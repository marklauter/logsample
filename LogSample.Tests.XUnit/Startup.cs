using LogSample.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace LogSample.Tests.XUnit
{
    public sealed class Startup
    {
#pragma warning disable CA1822 // Mark members as static
        public void ConfigureServices(IServiceCollection services)
#pragma warning restore CA1822 // Mark members as static
        {
            _ = services
                .AddLogging()
                .AddSampleService();
        }

#pragma warning disable CA1822 // Mark members as static
        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
#pragma warning disable IDISP004 // Don't ignore created IDisposable
            loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (source, ll) => ll >= LogLevel.Trace));
#pragma warning restore IDISP004 // Don't ignore created IDisposable
        }
#pragma warning restore CA1822 // Mark members as static
    }
}
