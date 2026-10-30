using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogApi.Endpoints;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var sub = user.FindFirstValue(JwtRegisteredClaimNames.Sub);
        return Guid.TryParse(sub, out var id) ? id : throw new InvalidOperationException("The token has no valid 'sub' claim");
    }
}