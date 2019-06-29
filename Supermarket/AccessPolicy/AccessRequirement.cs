using Microsoft.AspNetCore.Authorization;

namespace Supermarket.AccessPolicy
{
    public class AccessRequirement : IAuthorizationRequirement
    {
        public string Role { get; private set; }
        public AccessRequirement(string role)
        {
            Role = role;
        }
    }
}
