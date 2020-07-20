using System.Threading.Tasks;
using HelloApp.Models;
using Microsoft.AspNetCore.Http;

namespace HelloApp.Middleware
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITimeProvider timeProvider)
        {
            await _next.Invoke(context);

            var path = context.Request.Path;
            if (path.StartsWithSegments("/home/time"))
            {
                await context.Response.WriteAsync($"<h2>Time: {timeProvider.GetTime()}</h2>" +
                                                  $"<h3>timeProvider.GetHashCode: {timeProvider.GetHashCode()}</h3>");
            }
        }
    }
}