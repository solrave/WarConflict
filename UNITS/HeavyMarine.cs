using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS.Interfaces;

namespace WarConflict.Soldiers;

public class HeavyMarine : Soldier, IAttacker, IHealable
{
    public IWeapon Weapon { get; }
    
    public event Action<EventArgs>? OnAttack;
    

    public  int MaxHealth { get; }
    
    public int CurrentHealth { get;  set; }
    
    public override event Action<EventArgs> OnAction;
    
    public override event Action<EventArgs> OnDead;

    public HeavyMarine()
    {
        Weapon = new Shotgun();
        Rank = "Heavy Marine";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }

    public override void MakeAction()
    {
        throw new NotImplementedException();
    }

    public override void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
    
    public void Attack(Team team)
    {
        throw new NotImplementedException();
    }
    
    public void TakeHeal(int healingValue)
    {
        throw new NotImplementedException();
    }
}
