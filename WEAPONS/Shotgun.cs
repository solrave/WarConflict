using WarConflict.Soldiers;

namespace WarConflict.Weapons;

public class Shotgun : IWeapon
{
    private Random _randomizer = new();
    
    public event Action<MessageHandler>? AttackInfo;
    
    public event Action<ISoldier>? RemoveDead;

    private readonly string Name = "Shotgun";

    private readonly int WeaponDamage = 2;

    private List<int>? SplashDamage { get; set; }

    public void Shoot(ISoldier attacker, Team team)
    {
        var targetList = PickSoldiersToSplash(team);
        CreateSplashDamage();
        AttackInfo?.Invoke(new MessageHandler(attacker, Name, targetList, SplashDamage));
        ApplySplashDamage(targetList);
        RemoveDeadTargets(targetList);
    }

    private int CreateSplashDamage()
    {
        return _randomizer.Next((WeaponDamage) + 1);
    }
    
    private void ApplySplashDamage(IEnumerable<ISoldier> targetList)
    {
        foreach (var target in targetList)
        {
            target.TakeDamage(CreateSplashDamage);
        }
    }

    private void RemoveDeadTargets(List<ISoldier> targetList)
    {
        foreach (var target in targetList)
        {
            if (!target.IsAlive)
            {
                AttackInfo?.Invoke(new MessageHandler(target));
                RemoveDead?.Invoke(target);
            }
        }
    }
    
    private IEnumerable<ISoldier> PickSoldiersToSplash(Team team)
    {
        int splashRange = 3;
        int targetIndex = _randomizer.Next(team.Squad.Count - 1);
        if (team.Squad.Count < splashRange)
        {
            splashRange = team.Squad.Count;
            return team.Squad.Take(splashRange);
        }
        else if (targetIndex == team.Squad.Count)
        {
            return team.Squad.Skip(targetIndex - 1).Take(splashRange - 1);
        }
        else if (targetIndex == 0)
        {
            return team.Squad.Take(splashRange - 1);
        }
        else
        {
            return team.Squad.Skip(targetIndex - 1).Take(splashRange);
        }
    }
}