using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public class Medic : Soldier,IHealable, IHealer, IHittable
{
    private readonly BattleLogger _logger;
    
    private readonly int _armor;

    private Soldier _chosenOne;
    public int MaxHealth { get; }

    public int CurrentHealth { get; set; }

    public int HealingValue { get; set; }
    
    public Medic(string teamName, BattleLogger logger)
    {
        _logger = logger;
        TeamName = teamName;
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

    public void TakeHit(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - (damage - _armor), 0);
        _logger.Log($"{Rank} from {TeamName}'s team gets {damage} [DAMAGE]");

        if (CurrentHealth == 0)
        {
            IsAlive = false;
            _logger.Log($"[{Number}]{Rank} from {TeamName}'s team is [DEAD]");
        }
        
    }
    
    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [HEAL] {healingValue}HP");

    }

    public void Heal(Team team)
    {
        var soldierToHeal = GetHealableSoldier(team);
        if (soldierToHeal != null)
        {
            soldierToHeal.TakeHeal(HealingValue);
            _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [HEAL]" + 
                        $" {_chosenOne.Rank}{_chosenOne.Number}");
        }
        else
        {
            _logger.Log("No units to heal.");
        }
    }

    private IHealable? GetHealableSoldier(Team team)
    {
        //int chosenTargetIndex = Helper.GetRandom().Next(team.Squad.Count - 1);
        var healableCount = team.Squad.Count(s => s is IHealable);
        var chosenTarget = Helper.GetRandom().Next(healableCount);
        _chosenOne = team.Squad[chosenTarget];
        return healableCount > 0
            ? team.Squad.OfType<IHealable>()
                .Where(h => h.CurrentHealth < MaxHealth)
                .ElementAt(chosenTarget)
            : null;
    }
    
}
