```bash
# Unit Testing – xUnit
dotnet new xunit -n BlogApi.Tests
dotnet add BlogApi.Tests/BlogApi.Tests.csproj reference BlogApi/BlogApi.csproj
dotnet sln add BlogApi.Tests/BlogApi.Tests.csproj

# Integration Testing
dotnet add BlogApi.Tests/BlogApi.Tests.csproj package Microsoft.AspNetCore.Mvc.Testing

# Metrics – dotnet-counters (global tool)
dotnet tool list --global
dotnet tool install --global dotnet-counters

# Run all tests
dotnet test BlogApi.Tests/BlogApi.Tests.csproj

# Run a specific test class
dotnet test BlogApi.Tests/BlogApi.Tests.csproj --filter ClaimsPrincipalTests

# Metrics – find the running BlogApi process
dotnet-counters ps

# Metrics – monitor HTTP requests
dotnet-counters monitor --process-id <PID> --counters Microsoft.AspNetCore.Hosting
```
