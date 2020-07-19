using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
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
            var path = context.Request.Path;
            if (path.StartsWithSegments("/home/time"))
            {
                await _next.Invoke(context);
                await context.Response.WriteAsync($"<h2>Time: " +
                                                  $"{_timeProvider.GetTime()}</h2>");
            }
        }
    }
}