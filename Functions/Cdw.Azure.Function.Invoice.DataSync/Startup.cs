using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Identity;
using Cdw.Azure.Function.Sample;
using Cdw.Azure.Function.Sample.Common;
using Cdw.Azure.Function.Sample.Services.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Datadog.Logs;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Cdw.Azure.Function.Sample
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup: FunctionsStartup
    {
        private readonly AppConfiguration _appConfiguration;
        private readonly AzureKeyVaultConfiguration _azureKeyVaultConfiguration;

        /// <summary>
        /// 
        /// </summary>
        public Startup()
        {
            _appConfiguration = new AppConfiguration();
            _azureKeyVaultConfiguration = new AzureKeyVaultConfiguration();
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var context = builder.GetContext();

            // Add appSettings.json by environment
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appSettings.json"), optional: true, reloadOnChange: true)
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appSettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            configuration.GetSection("Configurations").Bind(_appConfiguration);
            configuration.GetSection("AzureKeyVaultConfig").Bind(_azureKeyVaultConfiguration);
            // Add azure credentials
            //builder.ConfigurationBuilder
            //    .AddAzureKeyVault(new Uri(_azureKeyVaultConfiguration.Endpoint), new DefaultAzureCredential());

            base.ConfigureAppConfiguration(builder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var context = builder.GetContext();

            builder.Services.AddCustomServices();

            //Configure Serilog DataDog sink
            var dataDogUrl = context.Configuration[_appConfiguration.DataDogUrl];
            //var dataDogApiKey = context.Configuration[_azureKeyVaultConfiguration.DataDogApiKey];
#pragma warning disable CS0219
            var dataDogApiKey = "B43103F3BC874A85A01671E91F9B4446";
#pragma warning restore CS0219
            // ReSharper disable once UnusedVariable
            var dataDogConfiguration = new DatadogConfiguration(url: dataDogUrl);
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Azure", LogEventLevel.Error)
                .WriteTo.Console()
                //.WriteTo.DatadogLogs(apiKey: dataDogApiKey, configuration: dataDogConfiguration, source: _appConfiguration.DataDogAppName)
                .CreateLogger();
            builder.Services.AddLogging(logBuilder =>
            {
                logBuilder.AddSerilog(Log.Logger, true);
            });
        }
    }
}
