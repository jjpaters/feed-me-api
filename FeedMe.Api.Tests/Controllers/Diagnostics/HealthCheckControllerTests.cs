using FeedMe.Api.Models.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace FeedMe.Api.Tests.Controllers.Diagnostics
{
    public class HealthCheckControllerTests : BaseControllerTests
    {
        [Fact]
        public async Task HealthCheckController_GetHealthCheck_Returns200()
        {
            // Act
            var response = await this.FunctionHandlerAsync("Controllers/Diagnostics/HealthCheckController-Get.json");

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact]
        public async Task HealthCheckController_GetHealthCheck_ReturnsPass()
        {
            // Act
            var response = await this.FunctionHandlerAsync("Controllers/Diagnostics/HealthCheckController-Get.json");

            var body = JsonConvert.DeserializeObject<HealthCheck>(response.Body);

            // Assert
            Assert.Equal(HealthStatuses.Pass, body.Status);
        }
    }
}
