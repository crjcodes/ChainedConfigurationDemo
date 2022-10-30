using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using ChainedConfigurationDemo;

Console.WriteLine("Starting demo...");

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        // if you have Azure set up, you can uncomment this section
        // See README for details

        //config.AddAzureAppConfiguration(options =>
        //{
        //    // This is a development-only approach used only locally
        //    // Here, the connection string to the read-only configuration property is set as a 
        //    // Windows user environment variable and read in from the environment here

        //    options
        //        .Connect(Environment.GetEnvironmentVariable("AZURE_APP_CONFIGURATION"))

        //        .Select(KeyFilter.Any, LabelFilter.Null)

        //        // if exists, overrides existing value, if any, from previous line
        //        .Select(KeyFilter.Any, "chained-configuration") 
        //        ;
        //});
    })
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



