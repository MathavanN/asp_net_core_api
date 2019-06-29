using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Supermarket.AccessPolicy
{
    public class AccessHandler : AuthorizationHandler<AccessRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRequirement requirement)
        {
            if (context.User.IsInRole(requirement.Role))
            {
                // Call 'Succeed' to mark current requirement as passed
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
