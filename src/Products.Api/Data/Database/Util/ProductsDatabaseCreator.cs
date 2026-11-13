using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Products.Api.Data.Database.Util;

public static class ProductsDatabaseCreator
{
    public static IServiceCollection AddProductsDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ProductsDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var environment = serviceProvider.GetRequiredService<IHostEnvironment>();

            var connectionString = configuration.GetConnectionString("ProductsDatabase") ?? throw new InvalidOperationException("Connection string 'ProductsDatabase' is not configured.");
            var sqliteConnectionString = new SqliteConnectionStringBuilder(connectionString);
            sqliteConnectionString.DataSource = Path.GetFullPath(
                sqliteConnectionString.DataSource,
                environment.ContentRootPath);

            var databaseDirectory = Path.GetDirectoryName(sqliteConnectionString.DataSource) ?? throw new InvalidOperationException("The ProductsDatabase path must include a directory.");
            Directory.CreateDirectory(databaseDirectory);

            options.UseSqlite(sqliteConnectionString.ToString());
        });

        return services;
    }
}
