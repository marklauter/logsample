# logsample
This solution provides simple logging samples using Microsoft.Extensions.Logging, Serilog, and XunitTestOutputLoggerProvider.
There are four projects in this solution: LogSample.Console, LogSample.Library, LogSample.Tests.Serilog, and LogSample.Tests.XUnit.

## Related Documentation
### Observability and Logging Guidance for Developers
https://github.com/marklauter/logsample/blob/main/Effective%20Logging%20for%20Optimal%20Observability.pdf
### Microsoft.Extensions.Logging
https://learn.microsoft.com/en-us/dotnet/core/extensions/logging
### Serilog
https://github.com/serilog
### XUnit
https://github.com/xunit
### XUnit Dependency Injection, XunitTestOutputLoggerProvider, and ITestOutputHelper
https://github.com/pengweiqhca/Xunit.DependencyInjection

Additional documentation can be found in the readme.md files in each project.

## Projects
### LogSample.Console
A console application that demos how to configure serilog with a host using the UseSerilog extension method and provides some compact JSON log output samples.
### LogSample.Library
A class library that demos how to inject ILogger<T> into a class that requires logging services, how to log simple messages, how to output objects as JSON using the @ modifier, and how to log exceptions.
### LogSample.Tests.Serilog
A unit test project that demos how to register Serilog as the ILogger provider, inject the ITestOutputHelper and set up Serilog to write to the output helper.
### LogSample.Tests.XUnit
A unit test project that demos how to register XunitTestOutputLoggerProvider as a logger factory provider.
