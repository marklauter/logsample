# logsample
This solution provides simple samples of logging using Microsoft.Extensions.Logging, Serilog, and XunitTestOutputLoggerProvider.
There are four projects in this solution: LogSample.Console, LogSample.Library, LogSample.Tests.Serilog, and LogSample.Tests.XUnit.
## LogSample.Console
A console application that demos how to configure serilog with a host using the UseSerilog extension method and provides some compact JSON log output samples.
## LogSample.Library
A class library that demos how to inject ILogger<T> into a class that requires logging services, how to log simple messages, how to output objects as JSON using the @ modifier, and how to log exceptions.
## LogSample.Tests.Serilog
A unit test project that demos how to register Serilog as the ILogger provider, inject the ITestOutputHelper and set up Serilog to write to the output helper.
## LogSample.Tests.XUnit
A unit test project that demos how to register XunitTestOutputLoggerProvider as a logger factory provider.
