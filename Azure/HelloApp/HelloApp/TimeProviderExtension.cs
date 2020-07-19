using Microsoft.Extensions.DependencyInjection;

namespace HelloApp
{
    public static class TimeProviderExtension
    {
        public static void AddTimeProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITimeProvider, TimeProvider>();
        }
    }
}