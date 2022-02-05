using HtmlAgilityPack;

namespace GitHubUpdater
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IGitRepoUpdater _gitRepoUpdater;

        public Worker(ILogger<Worker> logger, IGitRepoUpdater gitRepoUpdater)
        {
            _logger = logger;
            _gitRepoUpdater = gitRepoUpdater;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string tmp = string.Empty;

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                HtmlWeb web = new();
                HtmlDocument doc = web.Load("https://github.com/yaroslav1orlov/JS/commits/master");

                var xpath = "/html/body/div[4]/div/main/div[2]/div/div[2]/div[1]/div[2]/ol/li/div[2]/div[1]/a";
                HtmlNodeCollection? collection = doc.DocumentNode.SelectNodes(xpath);
                string link = collection[0].InnerText;

                if (!string.Equals(tmp, link))
                {
                    tmp = link;
                    _gitRepoUpdater.StartAsync();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }

}