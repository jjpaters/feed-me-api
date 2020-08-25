using System;
using System.Threading.Tasks;
using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using FeedMeApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeedMeApi.Controllers.Diagnostics
{
    /// <summary>
    /// Health Controller
    /// </summary>
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly UserManager<CognitoUser> userManager;

        public HealthController(UserManager<CognitoUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Check the health of the API.
        /// </summary>
        /// <returns>Status of the API</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetHealth()
        {
            var health = new Health
            {
                Status = HealthStatuses.Pass
            };

            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                health.Username = user?.Username;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return Ok(health);
        }
    }
}
