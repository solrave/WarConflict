using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS;

namespace WarConflict.UNITS;

public class Marine : Soldier, IHealable
{
    public Weapon Weapon { get; }

    public int MaxHealth { get; }

    public int CurrentHealth { get; set; }

    public override event Action<int> OnHit; 

    public override event Action<Soldier>? OnAction;

    public override event Action<Soldier>? OnDead;

    public event Action<IHittable, IHittable>? OnAttack;
    
    public event Action<int>? OnHeal;

    public Marine()
    {
        Weapon = new Rifle();
        Rank = "Marine";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }
    
    public override void MakeAction(Team team)
    {
        Attack(team);
        OnAction?.Invoke(this);
    }

    public override void TakeHit(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        if (CurrentHealth == 0)
        {
            IsAlive = false;
            OnDead?.Invoke(this);
        }
        OnHit?.Invoke(damage); 
    }
    
    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        OnHeal?.Invoke(healingValue);
    }
    
    private void Attack(Team team)
    {
        var target = Helper.GetRandomTarget(team);
        OnAttack?.Invoke(this, target); 
        Weapon.Shoot(target, team);
    }
}