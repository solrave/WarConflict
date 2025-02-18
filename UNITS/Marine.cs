using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS.Interfaces;

namespace WarConflict.Soldiers;
using static Console;
using System.Threading;
public class Marine : Soldier, IAttacker, IHealable
{
    public IWeapon Weapon { get; }

    public  int MaxHealth { get; }
    
    public int CurrentHealth { get;  set; }
    
    public override event Action<EventArgs> OnAction;
    
    public override event Action<EventArgs> OnDead;
    
    public event Action<EventArgs>? OnAttack;
    
    public Marine()
    {
        Weapon = new Rifle();
        Rank = "Marine";
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }
    public override void MakeAction()
    {
        throw new NotImplementedException();
        //OnAction?.Invoke(); 
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        if (CurrentHealth == 0)
        {
            IsAlive = false;
            //OnDead?.Invoke();
        }
        //OnAction?.Invoke(); 
    }
    
    public void Attack(Team team)
    {
        Weapon.Shoot(Helper.GetRandomTarget(team), team);
        //OnAttack?.Invoke(); 
    }
    
    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        //OnAction?.Invoke();
    }

}