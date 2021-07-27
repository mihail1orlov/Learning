using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace HelloApp.Middleware
{
    public class InfoMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public InfoMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            var sb = new StringBuilder();

            sb.Append($"</br><b>ApplicationName</b>: {_env.ApplicationName}");
            sb.Append($"</br><b>Environment</b>: {_env.EnvironmentName}");
            sb.Append($"</br><b>ContentRootPath</b>: {_env.ContentRootPath}");
            sb.Append($"</br><b>WebRootPath</b>: {_env.WebRootPath}");
            sb.Append($"</br><b>ContentRootFileProvider</b>: {_env.ContentRootFileProvider}");
            sb.Append($"</br><b>WebRootFileProvider</b>: {_env.WebRootFileProvider}");
            sb.Append($"</br><b>IsEnvironment(Development111)</b>: {_env.IsEnvironment("Development111")}");

            await context.Response.WriteAsync(sb.ToString());
        }
    }
}