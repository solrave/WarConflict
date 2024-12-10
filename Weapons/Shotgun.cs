using WarConflict.Soldiers;

namespace WarConflict.Weapons;

public class Shotgun : IWeapon
{
    private Random _randomizer = new();
    
    public event Action<ISoldier, ISoldier>? AttackInfo;
    
    public event Action<ISoldier, int>? DamageMessage;
    public event Action<ISoldier>? RemoveDead;

    public event Action<ISoldier, ISoldier, int, int> SplashMessage;
    
    public string Name { get; } = "Shotgun";
    
    public int WeaponDamage { get; } = 2;
    
    public int Damage { get; }

    public void Shoot(ISoldier attacker, Team team)
    {
        var targetIndex = Helper.PickSoldierByIndex(team);
        var target = team.Squad[targetIndex];
        ApplySplashDamage(team, targetIndex);
        AttackInfo?.Invoke(attacker,target);
        DamageMessage?.Invoke(target, Damage);
        //SplashMessage?.Invoke();///////////////////////////////////////////////////////
    }

    private void ApplyDamageToTarget(ISoldier target)
    {
        target.TakeDamage(Damage);
        DamageMessage?.Invoke(target, Damage);
    }

    private void ApplySplashDamage(Team team, int target)
    {
        int splashDamage1 = _randomizer.Next(0, 2);
        int splashDamage2 = _randomizer.Next(0, 2);
        team.Squad[target - 1].CurrentHealth -= splashDamage1;
        team.Squad[target + 1].CurrentHealth -= splashDamage2;
    }
}