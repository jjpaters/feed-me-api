using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMe.Api.Configuration
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        /// <summary>
        /// Ensure that the user have the scope claim, and succeed if scopes contains the required scope.
        /// </summary>
        /// <param name="context">Instance of AuthorizationHandlerContext</param>
        /// <param name="requirement">Instance of HasScopeRequirement</param>
        /// <returns>Completed task</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
            {
                // Split the scopes string into an array
                var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

                // Succeed if the scope array contains the required scope
                if (scopes.Any(s => s == requirement.Scope))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
