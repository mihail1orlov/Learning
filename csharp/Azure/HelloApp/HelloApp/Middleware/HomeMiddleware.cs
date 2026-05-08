using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp.Middleware
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
            await _next.Invoke(context);

            var path = context.Request.Path.Value.ToLower();
            if (path.StartsWith("/home"))
            {
                var token = "token=12345678";
                await context.Response.WriteAsync($"<a href='/home/info?{token}'>Info</a></br>" +
                                                  $"<a href='/home/content?{token}&age=44'>content</a></br></br>");
                if (path.StartsWith("/home/content"))
                {
                    if (int.TryParse(context.Request.Query["age"], out var age) && age > 18)
                    {
                        await context.Response.WriteAsync($"Super content 18+</br>For {context.Request.Query["age"]}</br>");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Your age is not old enough!!!</br>" +
                                                          $"For {context.Request.Query["age"]}</br>");
                    }
                }
            }
            else if (path.StartsWith("/about"))
            {
                await context.Response.WriteAsync("<h1>About page</h1>");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}