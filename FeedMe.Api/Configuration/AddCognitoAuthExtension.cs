using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net;

namespace FeedMe.Api.Configuration
{
    public static class AddCognitoAuthExtension
    {
        public static IServiceCollection AddCognitoAuth(this IServiceCollection services, IConfiguration config)
        {
            var cognitoIssuer = $"https://cognito-idp.{config["AWS:Region"]}.amazonaws.com/{config["AWS:UserPoolId"]}";
            var jwtKeySetUrl = $"{cognitoIssuer}/.well-known/jwks.json";
            var cognitoAudience = config["AWS:UserPoolClientId"];

            var parameters = new TokenValidationParameters
            {
                IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                {
                    var json = new WebClient().DownloadString(jwtKeySetUrl);
                    var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
                    return keys;
                },
                ValidIssuer = cognitoIssuer,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidAudience = cognitoAudience
            };

            services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = parameters;
            });

            return services;
        }
    }
}
