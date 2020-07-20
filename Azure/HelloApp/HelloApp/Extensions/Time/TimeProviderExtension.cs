using HelloApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp.Extensions.Time
{
    public static class TimeProviderExtension
    {
        public static void AddTimeProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITime, Models.Time>();
            serviceCollection.AddScoped<ITimeProvider, TimeProvider>();
        }
    }
}