using HelloApp.Extensions;
using HelloApp.Extensions.Time;
using HelloApp.Middleware;
using HelloApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private IServiceCollection _serviceCollection;

        //  IWebHostEnvironment (передает информацию о среде, в которой запускается приложение,
        // и его использовать при обработке запроса)
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;

            serviceCollection.AddTransient<IMessageService, SmsMessageService>();
            serviceCollection.AddTimeProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            // если приложение в процессе разработки
            if (env.IsDevelopment() || env.IsEnvironment("Development111"))
            {
                // то выводим информацию об ошибке, при наличии ошибки
                applicationBuilder.UseDeveloperExceptionPage();
            }

            applicationBuilder.UseDirectoryBrowser();
            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseStatusCodePages();

            MiddlewareModules(applicationBuilder, env);
        }

        private void MiddlewareModules(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            applicationBuilder.UseExceptionHandler("/error");
            applicationBuilder.UseMiddleware<ErrorHandlerMiddleware>();

            applicationBuilder.Use(async (context, next) =>
            {
                var token = "token=12345678";
                await context.Response.WriteAsync($"<a href='/error/?{token}'>Error</a></br>" +
                                                  $"<a href='/about?{token}'>About</a></br>" +
                                                  $"<a href='/home/?{token}'>home</a></br>" +
                                                  $"<a href='/home/time?{token}'>Time</a></br>" +
                                                  $"<a href='/home/message?{token}'>send message</a></br>" +
                                                  $"<a href='/home/services?{token}'>service collection</a></br>" +
                                                  $"<a href='/home/content?{token}&age=20'>content for 20</a></br>" +
                                                  $"<a href='/home/content?{token}&age=12'>content for 12</a></br>" +
                                                  "<a href='/static/index.html'>index</a></br>");
                await next.Invoke();
            });

            applicationBuilder.UseMiddleware<MyAuthenticationMiddleware>("12345678");
            applicationBuilder.UseMiddleware<InfoMiddleware>(_env);
            applicationBuilder.UseHome();
            applicationBuilder.UseTime();
            applicationBuilder.UseMiddleware<MessageMiddleware>();
            applicationBuilder.UseMiddleware<ServiceCollectionMiddleware>(_serviceCollection);
            applicationBuilder.UseMiddleware<ErrorMiddleware>();
            applicationBuilder.UseMiddleware<TableMiddleware>();
            applicationBuilder.UseMiddleware<TableRowMiddleware>();
        }
    }
}