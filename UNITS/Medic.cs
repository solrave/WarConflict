using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public class Medic : ISoldier, IHealer
{
    private const int AbilityChance = 9;
    
    private const int HealingValue = 4;
    public event Action<MessageHandler>? AttackInfo;
    
    public int Armor { get; private set; }
    
    private readonly string _abilityName = "MedKit";
    
    public int Number { get; set; }
    
    public string FractionName { get; set; }
    
    public string Rank { get; }
    
    public bool IsAlive { get; set; }

    public Medic(MarineStats stats)
    {
        Rank = stats.Rank;
        Armor = stats.Armor;
        IsAlive = true;
    }
    
    public void FightAction(Team team, Team enemyTeam)
    {
        Heal(team);
    }

    public void TakeDamage(Func<int> damage)
    {
        int hpLeft = Armor - damage;
        if (hpLeft <= 0) Armor = 0;
        else Armor -= damage;
        if (Armor == 0)
        {
            IsAlive = false;
        }
        AttackInfo?.Invoke(new MessageHandler(this, damage));
    }
    
    public void Heal(Team team)
    {
        var ally = team.PickRandomSoldier();
        bool healableFound = false;
        while (!healableFound)
        {
            if (ally is IHealable healableAlly)
            {
                healableAlly.TakeHeal(1 + Helper.GetRandomNumber(HealingValue)); 
                AttackInfo?.Invoke(new MessageHandler(this, ally, _abilityName, HealingValue));
                healableFound = true;
            }
        }
    }

}
