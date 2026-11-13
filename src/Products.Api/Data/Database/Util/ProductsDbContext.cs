using Microsoft.EntityFrameworkCore;
using Products.Api.Data.Database.Model;

namespace Products.Api.Data.Database.Util;

public sealed class ProductsDbContext(DbContextOptions<ProductsDbContext> options) : DbContext(options)
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
}
