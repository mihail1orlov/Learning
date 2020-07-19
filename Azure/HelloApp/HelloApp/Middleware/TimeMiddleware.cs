using System.Threading.Tasks;
using HelloApp.Models;
using Microsoft.AspNetCore.Http;

namespace HelloApp.Middleware
{
    public class TimeMiddleware
    {
        private readonly ITimeProvider _timeProvider;
        private readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next, ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            var path = context.Request.Path;
            if (path.StartsWithSegments("/home/time"))
            {
                await context.Response.WriteAsync($"<h2>Time: {_timeProvider.GetTime()}</h2>" +
                                                  $"<h3>timeProvider.GetHashCode: {_timeProvider.GetHashCode()}</h3>");
            }
        }
    }
}