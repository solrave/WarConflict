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
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        IsAlive = true;
    }
    
    public override void MakeAction(Team team)
    {
        Attack(team);
    }

    public void TakeHit(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team gets {damage} [DAMAGE]");
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
    
    private void Attack(Team team)
    {
        int chosenTargetIndex = Helper.GetRandom().Next(team.Squad.Count - 1);
        _chosenTarget = team.Squad[chosenTargetIndex];
        var target = Helper.GetTargetToHit(team, chosenTargetIndex);
        _logger.Log($"[{Number}]{Rank} from {TeamName}'s team [ATTACK] [{_chosenTarget.Number}]" +
                    $"{_chosenTarget.Rank} from {_chosenTarget.TeamName}'s team");
        Weapon.Shoot(target, team);
    }
}