using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloApp.Middleware
{
    public class TableRowMiddleware
    {
        private readonly RequestDelegate _next;
        private int _rows = 2;
        private int _columns = 3;

        public TableRowMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                sb.Append("<tr>");
                for (int j = 0; j < _columns; j++)
                {
                    sb.Append($"<td>{i}{j}</td>");
                }

                sb.Append("</tr>");
            }

            _rows++;
            _columns++;

            await context.Response.WriteAsync(sb.ToString());
        }
    }
}