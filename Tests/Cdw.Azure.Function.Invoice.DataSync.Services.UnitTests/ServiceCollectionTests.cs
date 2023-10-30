using System.Diagnostics.CodeAnalysis;
using Cdw.Azure.Function.Sample.Facades.Interfaces;
using Cdw.Azure.Function.Sample.Services.Extensions;
using Cdw.Azure.Function.Sample.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cdw.Azure.Function.TimerTrigger.Template.Services.UnitTests
{
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class ServiceCollectionTests
    {
        [Fact]
        public void ServiceCollectionExtensions_Test()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddCustomServices();
            var builder = services.BuildServiceProvider();

            // Act
            var sampleFacade = builder.GetService<ISampleFacade>();
            var sampleService = builder.GetService<ISampleService>();

            // Assert
            Assert.NotNull(sampleFacade);
            Assert.NotNull(sampleService);
        }
    }
}
