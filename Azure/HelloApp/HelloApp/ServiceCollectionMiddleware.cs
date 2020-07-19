using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    internal class ServiceCollectionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceCollection _serviceCollection;

        public ServiceCollectionMiddleware(RequestDelegate next, IServiceCollection serviceCollection)
        {
            _next = next;
            _serviceCollection = serviceCollection;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            var path = context.Request.Path;
            if (path.StartsWithSegments("/home/services"))
            {

                var sb = new StringBuilder();
                sb.Append("<h1>All services</h1>");
                sb.Append("<table border='2'>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Implementation</th></tr>");
                for (var i = 0; i < _serviceCollection.Count; i++)
                {
                    var svc = _serviceCollection[i];
                    sb.Append("<tr>");
                    sb.Append($"<td>{i}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                await context.Response.WriteAsync(sb.ToString());
            }
        }
    }
}