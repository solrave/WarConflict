namespace WarConflict.Weapons;
using Soldiers;
public interface IWeapon
{
    public event Action<MessageHandler> AttackInfo;
    
    public event Action<ISoldier>? RemoveDead;
 
    public void Shoot(ISoldier  attacker, Team team);

}