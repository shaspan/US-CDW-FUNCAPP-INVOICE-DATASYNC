using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Cdw.Azure.Function.Sample.Common.UnitTests
{
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class AzureKeyVaultConfigurationTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void AzureKeyVaultConfiguration_Create_Test()
        {
            // Arrange
            const string test = "test";
            AzureKeyVaultConfiguration azureKeyVaultConfiguration = new();

            // Act
            azureKeyVaultConfiguration.Endpoint = test;
            azureKeyVaultConfiguration.DataDogApiKey = test;
            azureKeyVaultConfiguration.Prefix = test;

            // Assert
            Assert.Equal(test, azureKeyVaultConfiguration.Endpoint);
            Assert.Equal(test, azureKeyVaultConfiguration.DataDogApiKey);
            Assert.Equal(test, azureKeyVaultConfiguration.Prefix);
        }
    }
}
