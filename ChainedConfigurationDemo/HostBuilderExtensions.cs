using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ChainedConfigurationDemo;

public static class HostBuilderExtensions
{
    public static HostBuilderContext LogConfiguration(this HostBuilderContext hostContext)
    {
        Console.WriteLine("Logging Starting Configuration Via Host Context");

        // Add keywords here to exclude certain environmental variables, properties, and settings from logging
        // Screening here, as opposed to launchSettings or other configuration mechanism,
        // to avoid cluttering logging of the configuration

        var toExclude = new List<string>
        {
            "_",
            "APPDATA",
            "COMMON",
            "COMPAT_LAYER",
            "COMPUTER",
            "COMSPEC",
            "CONFIG",
            "content",
            "DISPLAY",
            "DRIVER",
            "HOME",
            "HOSTNAME",
            "LOGON",
            "MSBUILD",
            "OneDrive",
            "PATH",
            "PS1",
            "PROGRAM",
            "PROCESSOR",
            "PROCESSOR",
            "PUBLIC",
            "PWD",
            "SSH_",
            "SHL",
            "SHELL",
            "SYSTEM",
            "TEMP",
            "TERM",
            "TMP",
            "USER",
            "WINDIR",
            "MINGW",
        };

        var configurationPairs = hostContext.Configuration.AsEnumerable();

        foreach (var pair in configurationPairs)
        {
            if (toExclude.Any(exc => pair.Key.Contains(exc, StringComparison.InvariantCultureIgnoreCase)))
                continue;

            Console.WriteLine("Key: {0}, Value: {1}", pair.Key, pair.Value);
        }     

        return hostContext;
    }
}
