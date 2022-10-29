# What

This project demonstrates Microsoft's chained configuration behavior for .NET generic host apps.

Uses NET 6.0 and the generic host builder in a console app, with a "Greeting" property that is overridden with each chain in the configuration.

## Behavior

This is the order in which each chained configuration provider is applied.  Last one wins.

1. AppSettings.json
1. AppSettings.{DOTNET_ENVIRONMENT}.json
1. LaunchSettings.json (if DOTNET_ENVIRONMENT is "Development")
1. Environment variable
1. Command-line argument

# Why

Sometimes understanding the chained configuration and what overrides what can be a bigger learning curve than desired.

This demo is to help with your understanding of the order of the chained configuration in the context of most of the usual use cases.

# How

Run this project from the command line.

1. cd into the project directory
2. `dotnet run` for basic output
3. `dotnet run...` with variations of parameters for different use cases

# Use Cases

These assume a bash terminal.  Convert to commands for your favorite terminal/Powershell/CMD window.

When running from the command-line, clean (with no environment variables set):

1. Argument Trumps All

`dotnet publish -o pub; cd pub`
`./ChainedConfigurationDemo.exe -- --Greeting=HelloFromArgs`


## Gotchas

- A `dotnet run` from the project directory will not catch the appsettings.json, hence the different running for that step







