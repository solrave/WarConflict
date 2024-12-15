using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public class HeavyMarine : ISoldier
{
    private const int AbilityChance = 4;
    
    public event Action<MessageHandler>? AttackInfo;
    
    public IWeapon Weapon { get; }
    
    public int Number { get; set; }
    
    public string FractionName { get; set; }
    
    public string Rank { get; }
    
    public  int MaxHealth { get; }
    
    public int CurrentHealth { get;  set; }
    
    public bool IsAlive { get; set; }
    
    public int Defence { get; private set; } = 1;
    

    private string _abilityName = "Shield";

    public HeavyMarine(MarineStats stats)
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
        int actualDamage = (damage - Defence);
        if (TryToBlock())
        {
            UseAbility();
            int hpLeft = CurrentHealth - actualDamage;
            if (hpLeft <= 0)
            {
                CurrentHealth = 0;
                IsAlive = false;
            }
        }
        else CurrentHealth -= actualDamage;
            ResetDefence();
            if (CurrentHealth <= 0)
            {
                IsAlive = false;
            }
        AttackInfo?.Invoke(new MessageHandler(this, actualDamage));
    }

    private void UseAbility()
    {
        Defence += 1;
        AttackInfo?.Invoke(new MessageHandler(this,_abilityName, Defence));
    }

    private bool TryToBlock()
    {
        int abilityActual = Helper.GetRandomNumber();
        if (AbilityChance > abilityActual)
        {
            return true;
        }

        return false;
    }

    private void ResetDefence()
    {
        Defence = 1;
    }
}