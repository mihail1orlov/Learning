namespace WorkerServer;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private HttpClient _client;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancelationToken)
    {
        _client = new HttpClient();
        return base.StartAsync(cancelationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _client.Dispose();
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var result = await _client.GetAsync("https://www.google.com", stoppingToken);

            if (result.IsSuccessStatusCode)
            {
                _logger.LogInformation($"The website is up. Status code {result.StatusCode}");
            }
            else
            {
                _logger.LogError($"The website is up. Status code {result.StatusCode}");
            }

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(3000, stoppingToken);
        }
    }
}
