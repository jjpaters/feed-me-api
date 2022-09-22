using System.Threading.Tasks;
using FeedMe.Api.Models.Diagnostics;
using FeedMe.Api.Repositories.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FeedMe.Api.Controllers.Diagnostics
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheckRepository healthCheckRepository;

        public HealthCheckController(IHealthCheckRepository healthCheckRepository)
        {
            this.healthCheckRepository = healthCheckRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<HealthCheck>> GetHealthCheck()
        {
            var healthCheck = await this.healthCheckRepository.GetHealthCheck();

            return Ok(healthCheck);
        }
    }
}
