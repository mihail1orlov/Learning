using GitHubUpdater.Configuration;

namespace GitHubUpdater
{
    /// <summary>
    /// A class that configures the GitHubUpdater configuration.
    /// </summary>
    public static class GitHubUpdaterConfigurationExtension
    {
        public static void ConfigureGitHubUpdater(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GitHubUpdaterConfiguration>(
                configuration.GetSection(nameof(GitHubUpdaterConfiguration)));

            services.AddSingleton<IGitRepoUpdater, GitRepoUpdater>();
        }
    }
}