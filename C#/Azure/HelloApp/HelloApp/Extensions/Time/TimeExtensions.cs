using HelloApp.Middleware;
using Microsoft.AspNetCore.Builder;

namespace HelloApp.Extensions.Time
{
    public static class TimeExtensions
    {
        public static void UseTime(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<TimeMiddleware>();
        }
    }
}