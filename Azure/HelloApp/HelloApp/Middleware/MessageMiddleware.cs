using System.Threading.Tasks;
using HelloApp.Services;
using Microsoft.AspNetCore.Http;

namespace HelloApp.Middleware
{
    internal class MessageMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMessageService _service;

        public MessageMiddleware(RequestDelegate next, IMessageService service)
        {
            _next = next;
            _service = service;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            var path = context.Request.Path;
            if (path.StartsWithSegments("/home/message"))
            {
                await context.Response.WriteAsync(_service.Send());
            }
        }
    }
}