using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public class Medic : Soldier,IHealable, IHealer
{
    private readonly int _armor;
    public int MaxHealth { get; }
    
    public int CurrentHealth { get; set; }

    public int HealingValue { get; set; }

    public override event Action<int>? OnHit;
    
    public override event Action<Soldier>? OnAction;
    
    public override event Action<Soldier>? OnDead;
    
    public event Action<int>? OnHeal;
    
    public Medic()
    {
        Rank = "Medic";
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
        HealingValue = 10;
        _armor = 5;
        IsAlive = true;
    }

    public override void MakeAction(Team team)
    {
        Heal(team);
    }

    public override void TakeHit(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - (damage - _armor), 0);
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

    public void Heal(Team team)
    {
        var soldierToHeal = GetHealableSoldier(team);
        if (soldierToHeal != null) soldierToHeal.TakeHeal(HealingValue);
        
    }

    private IHealable? GetHealableSoldier(Team team)
    {
        var healableCount = team.Squad.Count(s => s is IHealable);
        return healableCount > 0
            ? team.Squad.OfType<IHealable>().ElementAt(Helper.GetRandom().Next(healableCount))
            : null;
    }
    
}
