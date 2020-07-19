using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            if (path.StartsWithSegments("/error"))
            {
                await context.Response.WriteAsync("Error handler page");
                return;
            }

            await _next.Invoke(context);

            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("<h1>Error handler!</h1>" +
                                                  "<h1>Token is invalid</h1>" +
                                                  "<a href='home/?token=12345678'>link with token</a>");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("Page is not found. Error 404!");
            }
        }
    }
}