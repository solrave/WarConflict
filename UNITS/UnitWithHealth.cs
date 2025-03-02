namespace WarConflict.UNITS;

public abstract class UnitWithHealth
{
    public abstract int MaxHealth { get; }
    
    public abstract int CurrentHealth { get;  set; }
}