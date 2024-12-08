namespace WarConflict.Weapons;
using Soldiers;
public interface IWeapon
{
    public string Name { get; }
    public int Damage { get; }
    public void Shoot(ISoldier soldier);
}