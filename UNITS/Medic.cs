using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public class Medic : Soldier, IHealable
{
    private const int ABILITY_CHANCE_RANGE = 12;

    private readonly int _armor;

    private readonly BattleLogger _logger;
    private readonly int ABILITY_SUCCESS = 5;

    public Medic(string teamName, BattleLogger logger)
    {
        _logger = logger;
        TeamName = teamName;
        Rank = "Medic";
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        HealingValue = 3;
        _armor = 5;
        IsAlive = true;
    }

    private int HealingValue { get; }


    public int MaxHealth { get; }

    public int CurrentHealth { get; private set; }

    public void TakeHeal(int healingValue)
    {
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team [RESTORES] {healingValue}HP");
        CurrentHealth = Math.Min(CurrentHealth + healingValue, MaxHealth);
    }

    public override void MakeAction(Team friendlyTeam, Team enemyTeam)
    {
        if (IsBlind)
        {
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [BLIND]");
            IsBlind = false;
            return;
        }

        TryUseAbility(enemyTeam);
        Heal(friendlyTeam);
    }

    public override void TakeHit(int damage)
    {
        var actualDamage = damage - _armor > 0 ? damage - _armor : 0;
        _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team gets {actualDamage} [DAMAGE]");
        CurrentHealth = Math.Max(CurrentHealth - actualDamage, 0);

        if (CurrentHealth == 0)
        {
            IsAlive = false;
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [DEAD]");
        }
    }

    private void Heal(Team team)
    {
        var soldierToHeal = GetHealableSoldier(team);
        if (soldierToHeal != null)
        {
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team [HEALS]");
            soldierToHeal.TakeHeal(HealingValue);
        }
        else
        {
            _logger.Log("No units to heal.");
        }
    }

    private IHealable? GetHealableSoldier(Team team)
    {
        var healableTargets = team.Squad.OfType<IHealable>()
            .Where(t => t.CurrentHealth < t.MaxHealth);
        return healableTargets.Any()
            ? healableTargets.ElementAt(Helper.GetRandomValue(healableTargets.Count()))
            : null;
    }

    private void TryUseAbility(Team enemyTeam)
    {
        if (ABILITY_SUCCESS > Helper.GetRandomValue(ABILITY_CHANCE_RANGE))
        {
            var target = Helper.GetRandomSoldier(enemyTeam.Squad);
            if (target.IsBlind) return;
            target.IsBlind = true;
            _logger.Log($"[{IdNumber}]{Rank} from {TeamName}'s team is [USING ABILITY]");
        }
    }
}