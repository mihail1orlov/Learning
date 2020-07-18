using Microsoft.AspNetCore.Builder;

namespace HelloApp
{
    public static class HomeExtensions
    {
        public static IApplicationBuilder UseHome(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HomeMiddleware>();
        }
    }
}