using TeachingHydroAnalysis.Database;
using TeachingHydroAnalysis.Types;

namespace TeachingHydroAnalysis;

public sealed class Service : IService
{
    private readonly IDatabase _database;

    public Service(IDatabase database)
    {
        _database = database;
    }

    public async Task<Site[]> GetSitesAsync()
    {
        await using var command = _database.CreateCommand("SELECT id, name from public.sites");
        await using var reader = await command.ExecuteReaderAsync();

        var sites = new List<Site>();

        while (await reader.ReadAsync())
        {
            var id = reader.GetInt32(0);
            var name = reader.GetString(1);
            var site = new Site(id, name);

            sites.Add(site);
        }

        return sites.ToArray();
    }
}