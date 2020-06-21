using FeedMeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedMeApi.Controllers.Diagnostics
{
    /// <summary>
    /// Health Controller
    /// </summary>
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {


        /// <summary>
        /// Check the health of the API.
        /// </summary>
        /// <returns>Status of the API</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult GetHealth()
        {
            var health = new Health
            {
                Status = HealthStatuses.Pass
            };

            return Ok(health);
        }
    }
}
