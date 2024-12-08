namespace WarConflict.Soldiers;

public class MarineStats
{
    public string Rank { get; private set; }
    public  int MaxHealth { get; private set; }
    public int Damage { get; private set; }

    public MarineStats()
    {
        Rank = "Marine";
        MaxHealth = 10;
        Damage = 2;
    }

    public MarineStats GetMarineStats()
    {
        return new MarineStats();
    }
}