using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public class MarineStats
{
    public string Rank { get; private set; }
    public  int MaxHealth { get; private set; }
    
    public IWeapon Weapon { get; private set; }

    public MarineStats()
    {
        Rank = "Marine";
        MaxHealth = 4;
        Weapon = new Rifle();
    }

    public MarineStats GetMarineStats()
    {
        return new MarineStats();
    }
}