using LogSample.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using System.Reflection;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => _ = services
            .AddSampleService())
    .UseSerilog((builderContext, services, configuration) => _ = configuration
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console(formatter: new CompactJsonFormatter())
#if DEBUG
            .WriteTo.Debug(formatter: new CompactJsonFormatter())
#endif
            .ReadFrom.Configuration(builderContext.Configuration)
            .Enrich.WithProperty("Application.Name", "LogSample.Console")
            .Enrich.WithProperty("Application.Version", Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "local-debug"))
    .Build();

var service = host.Services.GetRequiredService<ISampleService>();

var sampleData = new SampleData(Guid.NewGuid(), nameof(SampleData), DateTime.UtcNow);
service.Fail(sampleData);

