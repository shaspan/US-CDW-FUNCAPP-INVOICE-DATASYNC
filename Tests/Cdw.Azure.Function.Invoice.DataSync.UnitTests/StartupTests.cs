//using System;
//using System.Diagnostics.CodeAnalysis;
//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Extensions.DependencyInjection;
//using Moq;
//using Xunit;

//namespace Cdw.Azure.Function.Sample.UnitTests
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [Trait("Category", "CI")]
//    [ExcludeFromCodeCoverage]
//    public class StartupTests
//    {
//        [Fact]
//        public void ServiceCollectionExtensions_Test()
//        {
//            // Arrange
            

//            var functionConfigurationBuilderMock = new Mock<IFunctionsConfigurationBuilder>();
//            var startup = new Startup();
//            var webJobsBuilderContext = new WebJobsBuilderContext()
//            {
//                ApplicationRootPath = Environment.CurrentDirectory,
//                EnvironmentName = "Development"
//            };
//            var webJobsBuilder = new TestHostBuilder();
//            // Act
//            //var host = new HostBuilder()
//            //    .ConfigureAppConfiguration((context, builder) =>
//            //        startup.ConfigureAppConfiguration(new FunctionsConfigurationBuilder(builder, webJobsBuilderContext))
//            //    )
//            //    .Build();
//            startup.Configure(webJobsBuilder);
//            // Assert
//            //Assert.NotNull(host);
//        }
//    }

//    public class TestHostBuilder : IFunctionsHostBuilder
//    {
//        public TestHostBuilder()
//        {
//            Services = new ServiceCollection();
//        }
        
//        public IServiceCollection Services { get; }
//    }


//    public class TestWebJobsBuilder : IWebJobsBuilder
//    {
//        public TestWebJobsBuilder()
//        {
//            Services = new ServiceCollection();
//        }

//        public IServiceCollection Services { get; }
//    }
//    //internal class FunctionsConfigurationBuilder: IFunctionsHostBuilder
//    //{
//    //    public FunctionsConfigurationBuilder(IConfigurationBuilder configurationBuilder, WebJobsBuilderContext webJobsBuilderContext)
//    //    {
//    //        ConfigurationBuilder = configurationBuilder ?? throw new ArgumentNullException(nameof(configurationBuilder));
//    //        Context = new DefaultFunctionsHostBuilderContext(webJobsBuilderContext);
//    //    }

//    //    public IConfigurationBuilder ConfigurationBuilder { get; }

//    //    public FunctionsHostBuilderContext Context { get; }
//    //}

//    //internal class DefaultFunctionsHostBuilderContext : FunctionsHostBuilderContext
//    //{
//    //    public DefaultFunctionsHostBuilderContext(WebJobsBuilderContext webJobsBuilderContext)
//    //        : base(webJobsBuilderContext)
//    //    {
//    //    }
//    //}
//}
