namespace TeachingHydroAnalysis.Database;

public interface IConfiguration
{
    string Host { get; }
    int Port { get; }
    string User { get; }
    string Password { get; }
    string Database { get; }
}