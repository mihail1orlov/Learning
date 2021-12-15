using Serilog;
using Serilog.Events;
using WorkerServer;

try
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.File(@"Logs\LogFile.txt")
        .CreateLogger();

    IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services => { services.AddHostedService<Worker>(); })
        .UseSerilog()
        .Build();

    Log.Information("Starting up the service");

    await host.RunAsync();
}
catch (Exception e)
{
    Log.Fatal(e, "There was a problem starting the service");
}
finally
{
    Log.CloseAndFlush();
}