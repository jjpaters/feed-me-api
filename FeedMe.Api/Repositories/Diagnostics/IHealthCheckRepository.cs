using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Diagnostics
{
    public interface IHealthCheckRepository
    {
        /// <summary>
        /// Get the health check of the API.
        /// </summary>
        /// <returns>Current health check</returns>
        Task<Models.Diagnostics.HealthCheck> GetHealthCheck();
    }
}
