using HelloApp.Middleware;
using Microsoft.AspNetCore.Builder;

namespace HelloApp.Extensions
{
    public static class HomeExtensions
    {
        public static IApplicationBuilder UseHome(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HomeMiddleware>();
        }
    }
}