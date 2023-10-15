namespace TeachingHydroAnalysis.Types;

public class Site
{
    public Site(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}