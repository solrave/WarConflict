using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public abstract class Soldier : IHittable, IMakeAction
{
    public string? FractionName { get; init; }
    
    public string? Rank { get; protected init; }
    
    public int Number { get; set; }
    
    public bool IsAlive { get; protected set; }
    
    public abstract event Action<int>? OnHit;
    
    public abstract event Action<Soldier>? OnAction;
    
    public abstract event Action<Soldier>? OnDead;

    public abstract void MakeAction(Team team);

    public abstract void TakeHit(int damage);

}