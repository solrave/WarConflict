using System.Reflection.Metadata;
using WarConflict.Weapons;

namespace WarConflict.Soldiers;
using static Console;
using System.Threading;
public class Marine : ISoldier, IAttacker, IHealable
{
    private const int AbilityChance = 6;
    
    public event Action<MessageHandler>? AttackInfo;
    
    public int AdditionalDamage { get; private set; }
    
    private string _abilityName = "StimPack";
    
    public IWeapon Weapon { get; }
    
    public int Number { get; set; }

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
    
    public void TakeHeal(int healingValue)
    {
        int healResult = CurrentHealth + healingValue;
        if (healResult > MaxHealth)
        {
            CurrentHealth += MaxHealth - CurrentHealth;
        }
        CurrentHealth += healingValue;
    }
    
    public void FightAction(Team team, Team enemyTeam)
    {
        Attack(enemyTeam);
    }

    public void Attack(Team team)
    {
        UseAbility();
        if (Weapon is Rifle rifle)
        {
            rifle.Shoot(this,team, AdditionalDamage);
        }
        else
        {
            Weapon?.Shoot(this, team);
        }
    }

    public void TakeDamage(Func<int> damage)
    {
        int hpLeft = CurrentHealth - damage;
        if (hpLeft <= 0) CurrentHealth = 0;
        else CurrentHealth -= damage;
        if (CurrentHealth == 0)
        {
            IsAlive = false;
        }
        AttackInfo?.Invoke(new MessageHandler(this, damage));
    }

    private void UseAbility()
    {
        if (TryUseAbility())
        {
            if (CurrentHealth > 4)
            {
                CurrentHealth -= 2;
                AdditionalDamage = 2;
                AttackInfo?.Invoke(new MessageHandler(this, _abilityName, AdditionalDamage));
            }

        }
    }

    private bool TryUseAbility()
        { 
            int abilityActual = Helper.GetRandomNumber(12);
            if (AbilityChance > abilityActual)
            {
                return true;
            }

            return false;
        }

}