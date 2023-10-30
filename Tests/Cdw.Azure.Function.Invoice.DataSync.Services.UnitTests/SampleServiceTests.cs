using System.Diagnostics.CodeAnalysis;
using Cdw.Azure.Function.Sample.Facades.Interfaces;
using Cdw.Azure.Function.Sample.Facades.Models;
using Cdw.Azure.Function.Sample.Services;
using Moq;
using Xunit;

namespace Cdw.Azure.Function.TimerTrigger.Template.Services.UnitTests
{
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class SampleServiceTests
    {
        [Fact]
        public async void SampleService_GetAsync()
        {
            // Arrange
            const string test = "test";
            var sampleFacadeModel = new SampleFacadeModel
            {
                Name = test
            };
            var sampleFacade = new Mock<ISampleFacade>();
            sampleFacade.Setup(_ => _.GetAsync()).ReturnsAsync(sampleFacadeModel);

            // Act
            var sampleService = new SampleService(sampleFacade.Object);
            var model = await sampleService.GetAsync().ConfigureAwait(false);

            // Assert
            Assert.NotNull(model);
            sampleFacade.Verify(_ => _.GetAsync(), Times.Once);
            Assert.Equal(test, model.Name);
        }
    }
}