namespace WarConflict.UNITS.Interfaces;

public interface IHealer
{
    public int HealingValue { get; set; }
    public void Heal(Team team);
}