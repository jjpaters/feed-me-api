using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Newtonsoft.Json;
using Xunit;

namespace FeedMeApi.Tests.Controllers.Diagnostics
{
    public class HealthControllerTests
    {
        [Fact]
        public async Task GetHealth_HealthyAPI_ReturnsPass()
        {
            // Arrange
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./Controllers/Diagnostics/HealthController-Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();

            // Act
            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Contains("\"status\":\"Pass\"", response.Body);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

    }
}
