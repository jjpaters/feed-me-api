using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using FeedMe.Api.Repositories.Diagnostics;
using FeedMe.Api.Repositories.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace FeedMe.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class AddDependenciesExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IHealthCheckRepository, HealthCheckRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            // DynamoDB
            var dynamoConfig = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(config["DynamoDB:Region"]),
            };

            if (!string.IsNullOrEmpty(config["DynamoDB:ServiceUrl"]))
            {
                dynamoConfig.ServiceURL = config["DynamoDB:ServiceUrl"];
            }

            var client = new AmazonDynamoDBClient(config["DynamoDB:AccessKey"], config["DynamoDB:SecretKey"], dynamoConfig);
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            return services;
        }
    }
}
