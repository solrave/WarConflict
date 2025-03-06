namespace WarConflict.UNITS.Interfaces;

public interface IHealable
{
    public int MaxHealth { get; }

    public int CurrentHealth { get; }
    public void TakeHeal(int healingValue);
    
}