using Products.Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddLocationHeaderTransformer();

var app = builder.Build();

app.UseStopwatch();

app.MapReverseProxy();

app.Run();
