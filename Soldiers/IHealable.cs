namespace WarConflict.Soldiers;

public interface IHealable
{
    public  int MaxHealth { get; }
    
    public int CurrentHealth { get;  set; }

    public void TakeHeal(int healingValue);
}