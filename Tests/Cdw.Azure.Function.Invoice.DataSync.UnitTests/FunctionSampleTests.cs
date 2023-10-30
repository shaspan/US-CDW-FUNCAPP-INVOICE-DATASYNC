using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Cdw.Azure.Function.Sample.Domain;
using Cdw.Azure.Function.Sample.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Moq;
using Xunit;

namespace Cdw.Azure.Function.Sample.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [Trait("Category", "CI")]
    [ExcludeFromCodeCoverage]
    public class FunctionSampleTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async void FunctionSample_RunAsync_Test()
        {
            // Arrange
            TimerSchedule schedule = new DailySchedule("2:00:00");
            TimerInfo timerInfo = new TimerInfo(schedule, new ScheduleStatus(), false);
            var logs = new List<string>();
            var sampleModel = new Domain.Sample();
            var sampleService = new Mock<ISampleService>();

            Environment.SetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT", "Development");
            sampleService.Setup(_ => _.GetAsync()).ReturnsAsync(sampleModel);
            //var logger = FunctionTestFactory.CreateLogger<FunctionTimerTriggerSample>(logs);

            // Act
            //FunctionTimerTriggerSample functionMock = new(sampleService.Object, logger);
           // await functionMock.RunAsync(timerInfo).ConfigureAwait(false);
            var message = logs[0];

            // Assert
            sampleService.Verify(_ => _.GetAsync(), Times.Once);
            Assert.Contains("C# Timer trigger function executed at", message);
        }
    }
}