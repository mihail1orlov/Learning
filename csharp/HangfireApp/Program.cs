using System;
using Hangfire;

namespace HangfireApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка сервера Hangfire
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HangfireExample;Integrated Security=True")
                .UseRecommendedSerializerSettings()
                .UseConsole();

            // Создаем объект BackgroundJobServer, который будет запускать фоновые задачи
            using (var server = new BackgroundJobServer())
            {
                // Создаем фоновую задачу, которая будет выполняться каждые 10 секунд
                RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello, world!"), Cron.Minutely);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
