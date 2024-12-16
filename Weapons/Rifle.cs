namespace WarConflict.Weapons;
using Soldiers;

public class Rifle : IWeapon
{
    
    public event Action<MessageHandler>? AttackInfo;
    public event Action<ISoldier>? RemoveDead;
    
    private readonly Random _randomizer = new();

    private bool _critApplied;

    private readonly string Name = "Rifle";

    private int _weaponDamage = 2;

    private readonly int CritDamage  = 2;

    private int Damage { get; set; }
   
    public void Shoot(ISoldier attacker, Team team)
    {
        var target = team.PickRandomSoldier();
        CreateDamage();
        ApplyDamage(target);
        AttackInfo?.Invoke(new MessageHandler(attacker, Name, target, Damage, _critApplied));
    }
    
    public void Shoot(ISoldier attacker, Team team, int additionalDamage)
    {
        _weaponDamage += additionalDamage;
        var target = team.PickRandomSoldier();
        CreateDamage();
        AttackInfo?.Invoke(new MessageHandler(attacker, Name, target, Damage, _critApplied));
        ApplyDamage(target);
        RemoveDeadTarget(target);
    }

    private void CreateDamage()
    {
        if (ApplyCriticalDamage())
        {
            Damage = _weaponDamage + CritDamage;
            _critApplied = true;
        }
        else
        {
            Damage = _weaponDamage;
            _critApplied = false;
        }
    }

    private void ApplyDamage(ISoldier target)
    {
        target.TakeDamage(Damage);
    }

    private bool ApplyCriticalDamage()
    {
        int critChance = _randomizer.Next(0, (_weaponDamage * 20));
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
            AttackInfo?.Invoke(new MessageHandler(target));
            RemoveDead?.Invoke(target);
        }  
    }
}