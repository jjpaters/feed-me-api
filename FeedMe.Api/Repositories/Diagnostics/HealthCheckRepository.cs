using Amazon.DynamoDBv2.DataModel;
using FeedMe.Api.Models.Diagnostics;
using System;
using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Diagnostics
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        public async Task<HealthCheck> GetHealthCheck()
        {
            var healthCheck = new HealthCheck
            {
                Time = DateTime.UtcNow
            };

            return healthCheck;
        }
    }
}
