using System.Text;
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
            var l = 2;
            var d = 3;

            var path = context.Request.Path.Value.ToLower();
            if (path.StartsWith("/home"))
            {
                var sb = new StringBuilder();
                sb.Append("<a href='/home/index'>Index</a>\n" +
                          "<a href='/home/about'>About</a></br></br>");

                sb.Append("<table border='2'>");

                for (int i = 0; i < l; i++)
                {
                    sb.Append("<tr>");
                    for (int j = 0; j < d; j++)
                    {
                        sb.Append($"<td>{i}{j}</td>");
                    }

                    sb.Append("</tr>");
                }

                sb.Append("</table>");

                await context.Response.WriteAsync(sb.ToString());

                l++;
                d++;
            }
        }
    }

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