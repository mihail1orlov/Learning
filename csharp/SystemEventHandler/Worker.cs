using System.Management;

namespace SystemEventHandler;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private EventWatcherUser _eventWatcherUser;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public override Task StartAsync(CancellationToken cancelationToken)
    {
        _eventWatcherUser = new EventWatcherUser();
        return base.StartAsync(cancelationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("The server has been stopped...");
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _eventWatcherUser.DoWork();
        _logger.LogInformation("Start working...");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Keep alive");
            await Task.Delay(3000, stoppingToken);
        }

        _logger.LogInformation("Stop working...");
    }
}

public class EventWatcherUser : IDisposable
{
    private static readonly WqlEventQuery Query = new("__InstanceCreationEvent", new TimeSpan(0, 0, 1), "TargetInstance ISA \"Win32_LogonSession\"");
    private readonly ManagementEventWatcher _eLgiWatcher = new(Query);

    public void DoWork()
    {
        _eLgiWatcher.EventArrived += HandleEvent;
        _eLgiWatcher.Start();
    }

    private void HandleEvent(object sender, EventArrivedEventArgs e)
    {
        ManagementBaseObject f = (ManagementBaseObject)e.NewEvent["TargetInstance"];
        using StreamWriter fs = new StreamWriter("D:\\tmp\\status.log", true);

        fs.WriteLine($"LogonId: {f.Properties["LogonId"].Value}");
    }

    public void Dispose()
    {
        _eLgiWatcher.EventArrived -= HandleEvent;
    }
}