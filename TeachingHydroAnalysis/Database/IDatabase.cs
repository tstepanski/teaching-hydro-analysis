using System.Data.Common;

namespace TeachingHydroAnalysis.Database;

public interface IDatabase : IAsyncDisposable, IDisposable
{
    DbCommand CreateCommand(string commandText);
}