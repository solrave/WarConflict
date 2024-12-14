using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public class MarineStats
{
    public string Rank { get; private set; }
    public  int MaxHealth { get; private set; }
    
    public IWeapon Weapon { get; private set; }

    public MarineStats GetRifleMarineStats()
    {
        Rank = "Marine";
        MaxHealth = 4;
        Weapon = new Rifle();
        return this;
    }
    
    public MarineStats GetShotgunMarineStats()
    {
        Rank = "Heavy Marine";
        MaxHealth = 8;
        Weapon = new Shotgun();
        return this;
    }
}