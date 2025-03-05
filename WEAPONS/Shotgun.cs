using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;
using WarConflict.WEAPONS;

namespace WarConflict.Weapons;

public class Shotgun : Weapon
{
    private int SplashDamage => 8;

    public Shotgun()
    {
        Name = "Shotgun";
        Damage = 16;
    }

    public override void Shoot(IHittable target, Team team)
    {
        var targetList = PickTargetsToSplash(target, team);
        target.TakeHit(Damage);
        foreach (var indirectTarget in targetList)
        {
            indirectTarget.TakeHit(Helper.GetRandomValue(SplashDamage));
        }
    }
    
    private IEnumerable<IHittable> PickTargetsToSplash(IHittable target, Team team)
    {
        int index = team.Squad.Select((unit, index) => new { unit, index })
            .Where(soldier => soldier.unit.Equals(target))
            .Select(soldier => soldier.index)
            .FirstOrDefault(-1);
        
        if (index == -1) yield break;
        if (index > 0) yield return team.Squad.OfType<IHittable>().ElementAt(index - 1);
        if (index < team.Squad.Count - 1) yield return team.Squad.OfType<IHittable>().ElementAt(index + 1);
    }
}