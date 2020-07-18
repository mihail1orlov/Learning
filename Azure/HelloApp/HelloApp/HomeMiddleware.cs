using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    public class HomeMiddleware
    {
        private readonly RequestDelegate _next;

        public HomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();
            if (path.StartsWith("/home"))
            {
                await context.Response.WriteAsync("<a href='/home/index'>Index</a>\n");

                await _next.Invoke(context);

                await context.Response.WriteAsync("<a href='/home/index'>Index</a>\n" +
                                                  "<a href='/home/about'>About</a></br></br>");
            }
        }
    }
}