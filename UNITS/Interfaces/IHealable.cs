namespace WarConflict.UNITS.Interfaces;

public interface IHealable
{
    public  int MaxHealth { get; }
    
    public int CurrentHealth { get;  set; }
    
    public event Action<int>? OnHeal;
    
    public void TakeHeal(int healingValue);
    
}