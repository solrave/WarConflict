using System.Reflection.Metadata;
using WarConflict.Weapons;

namespace WarConflict.Soldiers;
using static Console;
using System.Threading;
public class Marine : ISoldier
{
    public IWeapon Weapon { get; }
    public string FractionName { get; set; }
    public string Rank { get; }
    public  int MaxHealth { get; }
    public int CurrentHealth { get;  set; }
    public bool IsAlive { get; set; } 

    public Marine(MarineStats stats)
    {
        Weapon = stats.Weapon;
        Rank = stats.Rank;
        MaxHealth = stats.MaxHealth;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }
    
    public void Attack(Team team)
    {
        Weapon.Shoot(this,team);
    }

    public void TakeDamage(int damage)
    {
        int hpLeft = CurrentHealth - damage;
        if (hpLeft <= 0) CurrentHealth = 0;
        else CurrentHealth -= damage;
        if (CurrentHealth == 0)
        {
            IsAlive = false;
        }
    }
}