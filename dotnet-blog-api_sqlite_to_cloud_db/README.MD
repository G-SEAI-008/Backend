```bash
# SQLite => Neon PostgreSQL

# 0. Navigate to the BlogApi project
cd BlogApi

# 1. Install PostgreSQL provider
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# 2. Check installed .NET tools
dotnet tool list --global

# Install EF Core CLI if it is not installed yet
dotnet tool install --global dotnet-ef

# 3. Initialize User Secrets (only if not configured yet)
dotnet user-secrets list # if not =>
dotnet user-secrets init

# 4. Save Neon connection string in User Secrets
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=YOUR-NEON-HOST"

# 5. Check User Secrets
dotnet user-secrets list

# 6. Back up the old SQLite Migrations folder
# Move Migrations OUTSIDE the project before creating new migrations.
# Keep the SQLite migrations as a backup.

# 7. Create a new PostgreSQL migration
dotnet ef migrations add InitialPostgres -o Data/Migrations


# 8. Apply migrations to Neon
dotnet ef database update

# 9. Run the API
dotnet run

# 10. Run existing tests (from the solution folder)
cd ..
dotnet test BlogApi.Tests/BlogApi.Tests.csproj
```
