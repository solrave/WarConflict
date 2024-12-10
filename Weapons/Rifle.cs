namespace WarConflict.Weapons;
using Soldiers;

public class Rifle : IWeapon
{
    private Random _randomizer = new();
    
    public event Action<ISoldier,ISoldier>? AttackInfo;
    public event Action<ISoldier, int>? DamageMessage;
    public event Action<ISoldier>? RemoveDead;

    public string Name { get; } = "Rifle";
    
    public int WeaponDamage { get; } = 2;
    
    public int CritDamage { get; } = 1;
    
    public int Damage { get; private set; } = 0;
   
    public void Shoot(ISoldier attacker, Team team)
    {
        var target = Helper.PickRandomSoldier(team);
        AttackInfo?.Invoke(attacker,target);
        if (ApplyCriticalDamage()) Damage = WeaponDamage + CritDamage;
        else Damage = WeaponDamage;
        ApplyDamageToTarget(target);
    }

    private void ApplyDamageToTarget(ISoldier target)
    {
        target.TakeDamage(Damage);
        DamageMessage?.Invoke(target, Damage);
        RemoveDead?.Invoke(target);            
    }

    private bool ApplyCriticalDamage()
    {
        int critChance = _randomizer.Next(0, (WeaponDamage * 20));
        if (critChance > 10 && critChance < 25)
        {
            return true;
        }
        return false;
    }
}