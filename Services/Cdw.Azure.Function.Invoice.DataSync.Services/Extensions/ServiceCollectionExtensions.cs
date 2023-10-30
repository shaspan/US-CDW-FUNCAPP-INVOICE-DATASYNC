using Cdw.Azure.Function.Sample.Facades.Extensions;
using Cdw.Azure.Function.Sample.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cdw.Azure.Function.Sample.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddCustomFacades();
            services.AddSingleton<ISampleService, SampleService>();

            return services;
        }
    }
}
