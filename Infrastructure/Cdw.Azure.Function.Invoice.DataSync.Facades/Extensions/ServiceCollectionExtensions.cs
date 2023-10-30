using Cdw.Azure.Function.Sample.Facades.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cdw.Azure.Function.Sample.Facades.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomFacades(this IServiceCollection services)
        {
            services.AddSingleton<ISampleFacade, SampleFacade>();

            return services;
        }
    }
}
