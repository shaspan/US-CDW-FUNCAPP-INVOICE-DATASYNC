using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Cdw.Azure.Function.Sample.Facades.UnitTests
{
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class SampleFacadeTests
    {
        [Fact]
        public async void SampleFacade_GetAsync()
        {
            // Arrange
            const string test = "sample";
            var sampleFacade = new SampleFacade();

            // Act
            var model = await sampleFacade.GetAsync().ConfigureAwait(false);

            // Assert
            Assert.NotNull(model);

            Assert.Equal(test, model.Name);
        }
    }
}