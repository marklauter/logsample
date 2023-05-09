using LogSample.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

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

        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor) =>
#pragma warning disable IDISP004 // Don't ignore created IDisposable
            loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (source, ll) => ll >= LogLevel.Trace));
#pragma warning restore IDISP004 // Don't ignore created IDisposable
    }
}
