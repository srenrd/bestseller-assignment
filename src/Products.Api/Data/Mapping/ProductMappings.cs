using Products.Api.Data.Database.Model;
using Products.Api.Data.Network.Model;

namespace Products.Api.Data.Mapping;

public static class ProductMappings
{
    public static ProductEntity ToEntity(this CreateProductModel model) => new()
    {
        Title = model.Title,
        Description = model.Description,
        Price = model.Price,
        Genre = model.Genre,
        Developer = model.Developer,
        Publisher = model.Publisher,
        ReleaseDate = model.ReleaseDate,
        Rating = model.Rating,
        CoverImage = model.CoverImage
    };
}
