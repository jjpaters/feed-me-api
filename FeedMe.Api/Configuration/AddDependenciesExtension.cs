using FeedMe.Api.Repositories.Diagnostics;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace FeedMe.Api.Configuration
{
    public static class AddDependenciesExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IHealthCheckRepository, HealthCheckRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            return services;
        }
    }
}
