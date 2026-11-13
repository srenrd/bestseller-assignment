using Microsoft.EntityFrameworkCore;
using Products.Api.Data.Database.Model;

namespace Products.Api.Data.Database.Util;

public static class DatabaseSeeder
{
    public static async Task SeedProductsDatabaseAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductsDbContext>();
        await SeedAsync(dbContext);
    }

    private static async Task SeedAsync(ProductsDbContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();

        if (await dbContext.Products.AnyAsync())
        {
            return;
        }

        var games = new[]
        {
            new ProductEntity
            {
                Title = "Disco Elysium: The Final Cut",
                Description = "An open-world role-playing game where you investigate a murder in a richly realized city.",
                Price = 39.99m,
                Genre = "Role-playing",
                Developer = "ZA/UM",
                Publisher = "ZA/UM",
                ReleaseDate = new DateOnly(2021, 3, 30),
                Rating = 97m
            },
            new ProductEntity
            {
                Title = "Half-Life 2",
                Description = "A first-person shooter following Gordon Freeman through a world under alien occupation.",
                Price = 9.99m,
                Genre = "First-person shooter",
                Developer = "Valve",
                Publisher = "Valve",
                ReleaseDate = new DateOnly(2004, 11, 16),
                Rating = 96m
            },
            new ProductEntity
            {
                Title = "Baldur's Gate 3",
                Description = "A party-based role-playing adventure set in the world of Dungeons & Dragons.",
                Price = 59.99m,
                Genre = "Role-playing",
                Developer = "Larian Studios",
                Publisher = "Larian Studios",
                ReleaseDate = new DateOnly(2023, 8, 3),
                Rating = 96m
            },
            new ProductEntity
            {
                Title = "BioShock",
                Description = "A first-person adventure exploring the underwater city of Rapture.",
                Price = 19.99m,
                Genre = "First-person shooter",
                Developer = "Irrational Games",
                Publisher = "2K",
                ReleaseDate = new DateOnly(2007, 8, 21),
                Rating = 96m
            },
            new ProductEntity
            {
                Title = "Grand Theft Auto V",
                Description = "An open-world action adventure following three criminals in Los Santos.",
                Price = 29.99m,
                Genre = "Action-adventure",
                Developer = "Rockstar North",
                Publisher = "Rockstar Games",
                ReleaseDate = new DateOnly(2015, 4, 14),
                Rating = 96m
            },
            new ProductEntity
            {
                Title = "Half-Life",
                Description = "A first-person shooter about a research experiment gone wrong at Black Mesa.",
                Price = 9.99m,
                Genre = "First-person shooter",
                Developer = "Valve",
                Publisher = "Sierra Studios",
                ReleaseDate = new DateOnly(1998, 11, 19),
                Rating = 96m
            },
            new ProductEntity
            {
                Title = "Portal 2",
                Description = "A first-person puzzle game about portals, physics, and escaping Aperture Science.",
                Price = 9.99m,
                Genre = "Puzzle-platformer",
                Developer = "Valve",
                Publisher = "Valve",
                ReleaseDate = new DateOnly(2011, 4, 19),
                Rating = 95m
            },
            new ProductEntity
            {
                Title = "Sid Meier's Civilization IV",
                Description = "A turn-based strategy game about building and leading a civilization through history.",
                Price = 29.99m,
                Genre = "Turn-based strategy",
                Developer = "Firaxis Games",
                Publisher = "2K Games",
                ReleaseDate = new DateOnly(2005, 10, 25),
                Rating = 94m
            },
            new ProductEntity
            {
                Title = "The Elder Scrolls V: Skyrim",
                Description = "An open-world role-playing game set in the northern province of Tamriel.",
                Price = 39.99m,
                Genre = "Role-playing",
                Developer = "Bethesda Game Studios",
                Publisher = "Bethesda Softworks",
                ReleaseDate = new DateOnly(2011, 11, 11),
                Rating = 94m
            },
            new ProductEntity
            {
                Title = "Mass Effect 2",
                Description = "A science-fiction role-playing adventure about assembling a crew to face a galactic threat.",
                Price = 29.99m,
                Genre = "Action role-playing",
                Developer = "BioWare",
                Publisher = "Electronic Arts",
                ReleaseDate = new DateOnly(2010, 1, 26),
                Rating = 94m
            }
        };

        dbContext.Products.AddRange(games);

        await dbContext.SaveChangesAsync();
    }
}
