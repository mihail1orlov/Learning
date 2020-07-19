using Microsoft.AspNetCore.Builder;

namespace HelloApp
{
    public static class TimeExtensions
    {
        public static void UseTime(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<TimeMiddleware>();
        }
    }
}