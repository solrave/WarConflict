using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS;

namespace WarConflict.UNITS;

public class Marine : Soldier, IHealable, IHittable
{
    private readonly BattleLogger _logger;
    
    private Soldier _chosenTarget;
    private Weapon Weapon { get; }

    public int MaxHealth { get; }

    public int CurrentHealth { get; set; }

    public Marine(string teamName, BattleLogger logger)
    {
        _logger = logger;
        TeamName = teamName;
        Weapon = new Rifle();
        Rank = "Marine";
        MaxHealth = 40;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }
    
    public override void MakeAction(Team friendlyTeam, Team  enemyTeam)
    {
        Attack(enemyTeam);
    }

    public void TakeHit(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team gets {damage} [DAMAGE]");
        if (CurrentHealth == 0)
        {
            _logger.LogThis($"[{Number}]{Rank} from {TeamName}'s team is [DEAD]");
            IsAlive = false;
        }
    }
    
    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [RESTORES] {healingValue}HP");
    }
    
    private void Attack(Team enemyTeam)
    {
        var target = Helper.GetTargetToHit(enemyTeam, Helper.GetRandomValue(enemyTeam.Squad.Count));
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [ATTACK]");
        Weapon.Shoot(target, enemyTeam);
    }
}