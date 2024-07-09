using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LE.ApiGateway.Extensions
{
    public static class HealthCheckExtentions
    {
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app, string path)
        {
            app.Use((ctx, next) =>
            {
                var requestPath = ctx.Request.Path.ToString();
                if (requestPath.Equals(path))
                {
                    return ctx.Response.WriteAsync("Ok");
                }
                return next.Invoke();
            });

            return app;
        }
    }
}
