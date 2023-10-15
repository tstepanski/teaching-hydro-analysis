using Microsoft.Extensions.Configuration;
using TeachingHydroAnalysis.Database;
using IConfiguration = TeachingHydroAnalysis.Database.IConfiguration;

namespace TeachingHydroAnalysis;

public static class Program
{
    public static Task Main()
    {
        var databaseConfiguration = GetDatabaseConfiguration();
        var database = new DatabaseWrapper(databaseConfiguration);
        var service = new Service(database);
        var inputOutput = new InputOutput(service, Console.In, Console.Out);

        return inputOutput.RunAsync();
    }

    private static IConfiguration GetDatabaseConfiguration()
    {
        var configurationManager = new ConfigurationBuilder();
        
        configurationManager
            .AddJsonFile("appsettings.json", false, false)
            .AddJsonFile("appsettings.alice.json", false, false);

        var databaseConfiguration = new Configuration();
        
        configurationManager
            .Build()
            .GetSection("Database")
            .Bind(databaseConfiguration);

        return databaseConfiguration;
    }
}