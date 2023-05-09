using LogSample.Library;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LogSample.Tests.Serilog
{
    public sealed class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services
                .AddLogging(builder => builder.AddSerilog(dispose: true))
                .AddSampleService();
        }
    }
}
