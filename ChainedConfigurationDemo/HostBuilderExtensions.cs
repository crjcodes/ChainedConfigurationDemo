using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ChainedConfigurationDemo;

public static class HostBuilderExtensions
{
    public static HostBuilderContext LogConfiguration(this HostBuilderContext hostContext)
    {
        var greeting = hostContext.Configuration.GetValue<string>("Greeting") ?? string.Empty;

        Console.WriteLine("Greeting = {0}", greeting);

        return hostContext;
    }
}
