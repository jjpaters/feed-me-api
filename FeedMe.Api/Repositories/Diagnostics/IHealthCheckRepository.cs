using System.Threading.Tasks;

namespace FeedMe.Api.Repositories.Diagnostics
{
    public interface IHealthCheckRepository
    {
        Task<Models.Diagnostics.HealthCheck> GetHealthCheck();
    }
}
