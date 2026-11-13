using Products.Api.Data.Database.Util;
using Products.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProductsDatabase();
builder.Services.AddValidation();

var app = builder.Build();

await app.SeedProductsDatabaseAsync();

app.MapProductsEndpoints();

app.Run();

public partial class Program { }
