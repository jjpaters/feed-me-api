using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FeedMe.Api.Tests.Controllers
{
    public class BaseControllerTests
    {
        public async Task<APIGatewayProxyResponse> FunctionHandlerAsync(string jsonRequestPath)
        {
            var lambdaFunction = new LambdaEntryPoint();
            var context = new TestLambdaContext();

            var fullPath = Path.Combine(AppContext.BaseDirectory, "../../../", jsonRequestPath);
            var requestStr = File.ReadAllText(fullPath);
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);            

            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            return response;
        }
    }
}
