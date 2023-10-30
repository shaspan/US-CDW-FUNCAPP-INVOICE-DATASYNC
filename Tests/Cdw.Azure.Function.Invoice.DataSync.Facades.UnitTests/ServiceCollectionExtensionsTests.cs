using System.Diagnostics.CodeAnalysis;
using Cdw.Azure.Function.Sample.Facades.Extensions;
using Cdw.Azure.Function.Sample.Facades.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cdw.Azure.Function.Sample.Facades.UnitTests
{
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void ServiceCollectionExtensions_Test()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddCustomFacades();
            var builder = services.BuildServiceProvider();

            // Act
            
            var sampleFacade = builder.GetService<ISampleFacade>();

            // Assert
            Assert.NotNull(sampleFacade);
        }
    }
}
