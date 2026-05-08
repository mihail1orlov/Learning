using System;
using Hangfire;

namespace HangfireApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the Hangfire server.
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HangfireExample;Integrated Security=True")
                .UseRecommendedSerializerSettings()
                .UseConsole();

            // BackgroundJobServer hosts the workers that execute background jobs.
            using (var server = new BackgroundJobServer())
            {
                // Register a recurring job that fires every minute.
                RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello, world!"), Cron.Minutely);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
