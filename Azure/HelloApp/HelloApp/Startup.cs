﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        //  IWebHostEnvironment (передает информацию о среде, в которой запускается приложение, и его использовать при обработке запроса)
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                applicationBuilder.UseDeveloperExceptionPage();
            }

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseMiddleware<ErrorHandlerMiddleware>();
            applicationBuilder.UseMiddleware<MyAuthenticationMiddleware>("12345678");
            applicationBuilder.UseMiddleware<InfoMiddleware>(_env);
            applicationBuilder.UseHome();

            applicationBuilder.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<a href='/static/index.html'>index</a></br>" +
                                                  "<a href='/home/content?token=12345678&age=20'>content for 20</a></br>" +
                                                  "<a href='/home/content?token=12345678&age=12'>content for 12</a>");
                await next.Invoke();
            });

            applicationBuilder.UseMiddleware<TableMiddleware>();
            applicationBuilder.UseMiddleware<TableRowMiddleware>();
        }
    }
}