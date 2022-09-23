using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace FeedMe.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class AddAuthExtension
    {
        public static IServiceCollection AddCustomAuth(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = config["Auth:Authority"];
                options.Audience = config["Auth:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:recipes", policy => policy.Requirements.Add(new HasScopeRequirement("read:recipes", config["Auth:Authority"])));
                options.AddPolicy("write:recipes", policy => policy.Requirements.Add(new HasScopeRequirement("write:recipes", config["Auth:Authority"])));
            });

            return services;
        }
    }
}
