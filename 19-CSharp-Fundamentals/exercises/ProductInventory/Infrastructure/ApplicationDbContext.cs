using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure;

public class ProductInventoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data source=products.db");
    }
}

