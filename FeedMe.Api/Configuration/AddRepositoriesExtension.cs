using FeedMe.Api.Repositories.Diagnostics;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.Extensions.DependencyInjection;

namespace FeedMe.Api.Configuration
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddTransient<IHealthCheckRepository, HealthCheckRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}
