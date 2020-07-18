using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;

        public TokenMiddleware(RequestDelegate next, string token)
        {
            _next = next;
            _token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != _token)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("<h1>Token is invalid</h1>" +
                                                  "<a href='home/?token=12345678'>link with token</a>");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}