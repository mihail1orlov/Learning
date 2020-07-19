using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    internal class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            var path = context.Request.Path;
            if (path.StartsWithSegments("/error"))
            {
                var b = 0;
                var c = 3 / b;
            }
        }
    }
}