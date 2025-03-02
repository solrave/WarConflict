namespace WarConflict.UNITS;

public record UnitInfo
{
    private string? Name;

    public UnitInfo(string name)
    {
        Name = name;
    }
    
    public UnitInfo(string name, int a)
    {
        Name = name;
    }
}

