using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    public class MyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;

        public MyAuthenticationMiddleware(RequestDelegate next, string token)
        {
            _next = next;
            _token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var key = "token";
            if (context.Request.Query.ContainsKey(key) && context.Request.Query[key] == _token)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;
            }
        }
    }
}