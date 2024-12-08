namespace WarConflict.Soldiers;

public class MarineStats
{
    public string Rank { get; private set; }
    public  int MaxHealth { get; private set; }

    public MarineStats()
    {
        Rank = "Marine";
        MaxHealth = 10;
    }

    public MarineStats GetMarineStats()
    {
        return new MarineStats();
    }
}