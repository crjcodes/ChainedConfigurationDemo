using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ChainedConfigurationDemo;

public static class HostBuilderExtensions
{
    public static HostBuilderContext LogConfiguration(this HostBuilderContext hostContext)
    {
        var greeting = hostContext.Configuration.GetValue<string>("Greeting") ?? string.Empty;

        Console.WriteLine("\nIn the end, the greeting is \"{0}\"", greeting);

        return hostContext;
    }
}
