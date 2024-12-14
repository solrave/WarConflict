namespace WarConflict.Weapons;
using Soldiers;

public class Rifle : IWeapon
{
    
    public event Action<MessageHandler>? AttackInfo;
    public event Action<ISoldier, int>? DamageMessage;
    public event Action<ISoldier>? RemoveDead;
    
    private readonly Random _randomizer = new();

    private bool _critApplied;

    private readonly string Name = "Rifle";

    private readonly int WeaponDamage = 2;

    private readonly int CritDamage  = 2;

    private int Damage { get; set; }
   
    public void Shoot(ISoldier attacker, Team team)
    {
        _critApplied = false;
        var target = team.PickRandomSoldier();
        CreateDamage();
        ApplyDamage(target);
        AttackInfo?.Invoke(new MessageHandler(attacker, Name, target, Damage, _critApplied));
    }

    private void CreateDamage()
    {
        if (ApplyCriticalDamage())
        {
            Damage = WeaponDamage + CritDamage;
            _critApplied = true;
        }
        else Damage = WeaponDamage;
        _critApplied = false;
    }

    private void ApplyDamage(ISoldier target)
    {
        target.TakeDamage(Damage);
        RemoveDeadTarget(target);
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

    private void RemoveDeadTarget(ISoldier target)
    {
        if (!target.IsAlive)
        { 
            RemoveDead?.Invoke(target);
        }  
    }
}