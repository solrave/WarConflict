using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;
using WarConflict.WEAPONS;

namespace WarConflict.UNITS;

public class HeavyMarine : Soldier, IHealable
{
    private readonly int _abilityChanceRange = 15;

    private readonly int _abilitySuccess = 9;
    private readonly BattleLogger _logger;

    private bool _abilityIsUsed;

    private int _armor;

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

    private Weapon Weapon { get; }

    public int MaxHealth { get; }

    public int CurrentHealth { get; set; }

    public void TakeHeal(int healingValue)
    {
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team [RESTORES] {healingValue}HP");
    }

    public override void MakeAction(Team team, Team enemyTeam)
    {
        if (IsBlind)
        {
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [BLIND]");
            IsBlind = false;
            return;
        }

        if (!_abilityIsUsed) TryUseAbility();
        Attack(enemyTeam);
    }

    public override void TakeHit(int damage)
    {
        var actualDamage = damage - _armor > 0 ? damage - _armor : 0;
        CurrentHealth = Math.Max(CurrentHealth - actualDamage, 0);
        if (_abilityIsUsed)
        {
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team has [SUPER_ARMOR]");
            _abilityIsUsed = false;
            _armor = 1;
        }

        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team gets {actualDamage} [DAMAGE]");
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

    private void TryUseAbility()
    {
        if (_abilitySuccess <= Helper.GetRandomValue(_abilityChanceRange)) return;
        _armor = 12;
        _abilityIsUsed = true;
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [USING ABILITY]");
    }
}