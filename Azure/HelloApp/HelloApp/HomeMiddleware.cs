﻿using System.Threading.Tasks;
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
                await context.Response.WriteAsync("<a href='/index'>Index</a></br>" +
                                                  "<a href='/home/content?token=12345678&age=44'>content</a></br></br>");
                if (path.StartsWith("/home/content"))
                {
                    await context.Response.WriteAsync($"Super content!!!\nFor {context.Request.Query["age"]}+</br>");
                }
                else
                {
                    await _next.Invoke(context);
                }

                await context.Response.WriteAsync("<a href='/about'>About</a></br></br>");
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