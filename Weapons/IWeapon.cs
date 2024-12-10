namespace WarConflict.Weapons;
using Soldiers;
public interface IWeapon
{
    public event Action<ISoldier,ISoldier> AttackInfo;
    public event Action<ISoldier,int> DamageMessage;
    public event Action<ISoldier>? RemoveDead;
    
    public string Name { get; }
    
    public int WeaponDamage { get; }
    
    public int Damage { get; }

    public int CritDamage => 0;

    public void Shoot(ISoldier  attacker, Team team);

}