using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Transforms;

namespace Products.Gateway.Extensions;

public static class LocationHeaderTransformer
{
    public static IReverseProxyBuilder AddLocationHeaderTransformer(this IReverseProxyBuilder builder)
    {
        return builder.AddTransforms(transformBuilderContext =>
        {
            transformBuilderContext.AddResponseTransform(responseContext =>
            {
                var createdPath = responseContext.HttpContext.Response.Headers.Location.ToString();
                if (createdPath.StartsWith("/products", StringComparison.OrdinalIgnoreCase))
                {
                    var newCreatedPath = $"/api{createdPath}";
                    responseContext.HttpContext.Response.Headers.Location = newCreatedPath;
                }

                return ValueTask.CompletedTask;
            });
        });
    }
}
