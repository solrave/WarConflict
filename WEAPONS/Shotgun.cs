using WarConflict.Soldiers;
using WarConflict.WEAPONS.Interfaces;

namespace WarConflict.Weapons;

public class Shotgun : IWeapon
{
    public string Name { get; set; } = "Shotgun";

    public int Damage { get; set; } = 3;
    
    public event Action<int>? InflictDamage;

    public void Shoot(Soldier target, Team team)
    {
        var targetList = PickTargetsToSplash(target, team);
    }
    
    private IEnumerable<Soldier> PickTargetsToSplash(Soldier target, Team team)
    {
        int index = team.Squad.IndexOf(target);
        if (index == -1) yield break;
        if (index > 0) yield return team.Squad[index - 1];
        if (index < team.Squad.Count - 1) yield return team.Squad[index + 1];
    }
}