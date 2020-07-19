using HelloApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp.Middleware
{
    public static class TimeProviderExtension
    {
        public static void AddTimeProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITimeProvider, TimeProvider>();
        }
    }
}