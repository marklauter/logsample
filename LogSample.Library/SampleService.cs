﻿using Microsoft.Extensions.Logging;

namespace LogSample.Library
{
    internal sealed class SampleService
        : ISampleService
    {
        private readonly ILogger<SampleService> logger;

        public SampleService(ILogger<SampleService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.logger.LogDebug("{MethodName}", "ctor");
        }

        public void Succeed(SampleData data)
        {
            using var logScope = this.logger.BeginScope("{MethodName}", nameof(Succeed));

            this.logger.LogTrace("This is a {Level} message.", LogLevel.Trace);
            this.logger.LogDebug("This is a {Level} message.", LogLevel.Debug);

            this.logger.LogInformation("info: {@Data}", data);
        }

        public void Fail(SampleData data)
        {
            using var logScope = this.logger.BeginScope("{MethodName}", nameof(Fail));
            try
            {
                this.logger.LogInformation("{@Data}", data);

                throw new SampleOuterException(
                    $"fail: {nameof(SampleOuterException)}",
                    new SampleInnerException($"fail: {nameof(SampleInnerException)}")
                    {
                        Data = { { "SampleData", data } }
                    });
            }
            catch (SampleOuterException ex)
            {
                this.logger.LogWarning(ex, "can't do the thing with this data: {@Data}", data);
            }
            catch (Exception ex)
            {
                this.logger.LogCritical(ex, "unexpected exception while doing the thing. system abort time.");
                throw;
            }
        }
    }
}
