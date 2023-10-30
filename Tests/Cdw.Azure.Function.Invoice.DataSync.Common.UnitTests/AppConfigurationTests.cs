using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Cdw.Azure.Function.Sample.Common.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class AppConfigurationTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void AppConfiguration_Create_Test()
        {
            // Arrange
            const string test = "test";
            AppConfiguration appConfiguration = new();

            // Act
            appConfiguration.DataDogAppName = test;
            appConfiguration.DataDogUrl = test;

            // Assert
            Assert.Equal(test, appConfiguration.DataDogAppName);
            Assert.Equal(test, appConfiguration.DataDogUrl);
        }
    }
}