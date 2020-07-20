using HelloApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp.Extensions
{
    public static class TimeProviderExtension
    {
        public static void AddTimeProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITimeProvider, TimeProvider>();
        }
    }
}