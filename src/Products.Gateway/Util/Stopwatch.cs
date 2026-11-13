using System.Diagnostics;

namespace Products.Gateway.Extensions;

public static class Stopwatch
{
    public static WebApplication UseStopwatch(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                await next(context);
            }
            finally
            {
                stopwatch.Stop();
                app.Logger.LogInformation(
                    "HTTP {Method} {Path} responded {StatusCode} in {ElapsedMilliseconds} ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    stopwatch.ElapsedMilliseconds);
            }
        });

        return app;
    }
}
