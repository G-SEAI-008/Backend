using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace BlogApi.Tests;

public class ApiTests
{
    private static WebApplicationFactory<Program> CreateFactory()
    {
        return new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Production");

                builder.ConfigureAppConfiguration((context, config) =>
                {
                    config.AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        ["Jwt:Key"] = new string('x', 64)
                    });
                });
            });
    }

    [Fact]
    public async Task Me_WithoutToken_Returns401()
    {
        //Arrange
        using var factory = CreateFactory();
        using var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/auth/me");

        // Assert
        Assert.Equal(401, (int)response.StatusCode);
    }
    [Fact]
    public async Task Unknown_Returns404()
    {
        // Arrange
        using var factory = CreateFactory();
        using var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/idontknowwhere");

        // Assert
        Assert.Equal(404, (int)response.StatusCode);
    }
}