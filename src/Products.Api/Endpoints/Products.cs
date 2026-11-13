using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Products.Api.Data.Database.Model;
using Products.Api.Data.Database.Util;
using Products.Api.Data.Mapping;
using Products.Api.Data.Network.Model;

namespace Products.Api.Endpoints;

public static class ProductsEndpoints
{
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var products = endpoints.MapGroup("/products");

        products.MapGet("/", GetProducts);
        products.MapGet("/{id:int}", GetProduct);
        products.MapPost("/", CreateProduct);

        return endpoints;
    }

    static async Task<List<ProductEntity>> GetProducts(ProductsDbContext dbContext) => await dbContext.Products.AsNoTracking().ToListAsync();

    static async Task<Results<Created<ProductEntity>, ValidationProblem>> CreateProduct(CreateProductModel request, ProductsDbContext dbContext)
    {
        var product = request.ToEntity();

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        var productPath = $"/products/{product.Id}";
        return TypedResults.Created(productPath, product);
    }

    static async Task<Results<Ok<ProductEntity>, NotFound>> GetProduct(int id, ProductsDbContext dbContext)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(product => product.Id == id);

        return product is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(product);
    }
}