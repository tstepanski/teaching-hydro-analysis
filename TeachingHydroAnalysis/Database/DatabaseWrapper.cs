using System.Data.Common;
using Npgsql;

namespace TeachingHydroAnalysis.Database;

public sealed class DatabaseWrapper : IDatabase
{
    private readonly NpgsqlDataSource _dataSource;

    public DatabaseWrapper(IConfiguration configuration)
    {
        var builder = new NpgsqlDataSourceBuilder
        {
            ConnectionStringBuilder =
            {
                Host = configuration.Host,
                Port = configuration.Port,
                Username = configuration.User,
                Password = configuration.Password,
                Database = configuration.Database,
                Pooling = true
            }
        };

        _dataSource = builder.Build();
    }

    public async ValueTask DisposeAsync()
    {
        await _dataSource.DisposeAsync();
    }

    public void Dispose()
    {
        _dataSource.Dispose();
    }

    public DbCommand CreateCommand(string commandText)
    {
        return _dataSource.CreateCommand(commandText);
    }
}