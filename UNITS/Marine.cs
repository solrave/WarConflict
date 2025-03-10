using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS;

namespace WarConflict.UNITS;

public class Marine : Soldier, IHealable
{
    private readonly BattleLogger _logger;

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

    private Weapon Weapon { get; }

    public int MaxHealth { get; }

    public int CurrentHealth { get; private set; }

    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team [RESTORES] {healingValue}HP");
    }

    public override void MakeAction(Team friendlyTeam, Team enemyTeam)
    {
        if (IsBlind)
        {
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [BLIND]");
            IsBlind = false;
            return;
        }

        Attack(enemyTeam);
    }

    public override void TakeHit(int damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team gets {damage} [DAMAGE]");
        if (CurrentHealth == 0)
        {
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [DEAD]");
            IsAlive = false;
        }
    }

    private void Attack(Team enemyTeam)
    {
        var target = Helper.GetRandomSoldier(enemyTeam.HitSquad);
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team [ATTACK]");
        Weapon.Shoot(target, enemyTeam);
    }
}