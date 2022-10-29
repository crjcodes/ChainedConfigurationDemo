using ChainedConfigurationDemo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Eventing.Reader;

Console.WriteLine("Starting demo");
Console.WriteLine("\nArguments:");

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureLogging((hostContext, logBuilder) =>
    {
        // ignore Microsoft Debug and Informational logging for this demo
        logBuilder
            .SetMinimumLevel(LogLevel.Debug)
            .AddFilter("Microsoft", LogLevel.Warning);

    })   
    .ConfigureServices((hostContext, services) =>
    {
        // log the configuration after all chained configurations are applied
        hostContext.LogConfiguration();

        Console.WriteLine("\nPress Ctrl-C to stop the host and exit.\n");
    });


var builtHost = hostBuilder.Build();
builtHost.Run();



