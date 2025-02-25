using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;
using WarConflict.WEAPONS;

namespace WarConflict.Weapons;

public class Shotgun : Weapon
{
    public int SplashDamage { get; set; } = 1;
    
    public override event Action<int>? InflictDamage;

    public Shotgun()
    {
        Name = "Shotgun";
        Damage = 3;
    }

    public override void Shoot(IHittable target, Team team)
    {
        InflictDamage?.Invoke(Damage);
        var targetList = PickTargetsToSplash(target, team);
        target.TakeHit(Damage);
        foreach (var indirectTarget in targetList)
        {
            indirectTarget.TakeHit(SplashDamage);
        }
    }
    
    private IEnumerable<IHittable> PickTargetsToSplash(IHittable target, Team team)
    {
        int index = team.Squad.Select((unit, index) => new { unit, index })
            .Where(soldier => soldier.unit.Equals(target))
            .Select(soldier => soldier.index)
            .FirstOrDefault(-1);
        
        if (index == -1) yield break;
        if (index > 0) yield return team.Squad[index - 1];
        if (index < team.Squad.Count - 1) yield return team.Squad[index + 1];
    }
}