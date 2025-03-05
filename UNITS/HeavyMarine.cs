using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS;

namespace WarConflict.UNITS;

public class HeavyMarine : Soldier, IHealable, IHittable
{
    private readonly BattleLogger _logger;

    private Soldier _chosenTarget;
    
    private readonly int _armor;
    private Weapon Weapon { get; }

    public int MaxHealth { get; }

    public int CurrentHealth { get;  set; }
    
    public event Action<int>? OnHealing;

    public HeavyMarine(string teamName, BattleLogger logger)
    {
        _logger = logger;
        TeamName = teamName;
        Weapon = new Shotgun();
        Rank = "Heavy Marine";
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        _armor = 1;
        IsAlive = true;
    }

    public override void MakeAction(Team team, Team enemyTeam)
    {
        if (IsBlind)
        {
            _logger.Log($"[{Number}]{Rank} from {TeamName}'s team is [BLIND]");
            IsBlind = false;
            return;
        }
        Attack(enemyTeam);
    }

    public void TakeHit(int damage)
    {
        int actualDamage = damage - _armor > 0 ? damage - _armor : 0;
        CurrentHealth = Math.Max(CurrentHealth - actualDamage, 0);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team gets {damage} [DAMAGE]");
        if (CurrentHealth == 0)
        {
            _logger.Log($"[{Number}]{Rank} from {TeamName}'s team is [DEAD]");
            IsAlive = false;
        }
    }
    
    public void Attack(Team enemyTeam)
    {
        var target = Helper.GetTargetToHit(enemyTeam, Helper.GetRandomValue(enemyTeam.Squad.Count));
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [ATTACK]");
        Weapon.Shoot(target, enemyTeam);
    }
    
    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [RESTORES] {healingValue}HP");
    }
    
}
