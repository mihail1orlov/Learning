using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    public class TableMiddleware
    {
        private readonly RequestDelegate _next;
        public TableMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("<table border='2'>");
            
            await _next.Invoke(context);
         
            await context.Response.WriteAsync("</table>");
        }
    }
}