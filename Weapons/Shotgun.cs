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

    private void CreateSplashDamage()
    {
        SplashDamage = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            SplashDamage.Add((_randomizer.Next(WeaponDamage)) + 1);
        }
    }
    
    private void ApplySplashDamage(List<ISoldier> targetList)
    {
        for (int i = 0; i < targetList.Count; i++)
        {
            targetList[i].TakeDamage(SplashDamage[i]);
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
    
    private List<ISoldier> PickSoldiersToSplash(Team team)
    {
        int count = 3;
        if (team.Squad.Count < count)
        {
            count = team.Squad.Count;
        }
        
        int startIndex = _randomizer.Next(team.Squad.Count - count + 1);

        return team.Squad.GetRange(startIndex, count);
    }
}