using TeachingHydroAnalysis.Types;

namespace TeachingHydroAnalysis;

public interface IService
{
    Task<Site[]> GetSitesAsync();
}