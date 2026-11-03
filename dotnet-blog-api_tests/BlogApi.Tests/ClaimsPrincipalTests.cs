using System.Security.Claims;
using BlogApi.Endpoints;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BlogApi.Tests;

public class ClaimsPrincipalTests
{
    [Fact]
    public void GetUserId_ReturnsCorrectId()
    {
        // Arrange
        var userId = Guid.NewGuid();

        var user = new ClaimsPrincipal(
            new ClaimsIdentity([
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString())
            ]));

        // Act
        var result = user.GetUserId();

        // Assert
        Assert.Equal(userId, result);
    }
}