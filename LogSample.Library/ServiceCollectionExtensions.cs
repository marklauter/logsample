using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LogSample.Library
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSampleService(this IServiceCollection services)
        {
            services.TryAddTransient<ISampleService, SampleService>();
            return services;
        }
    }
}
