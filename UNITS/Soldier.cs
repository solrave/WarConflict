namespace WarConflict.Soldiers;

public abstract class Soldier
{
    public string? FractionName { get; set; }
    
    public string? Rank { get; set; }
    
    public int Number { get; set; }
    
    public bool IsAlive { get; set; }
    
    public abstract event Action<EventArgs> OnAction;
    
    //public abstract event Action<EventArgs> OnDamageReceiving;
    
    public abstract event Action<EventArgs> OnDead;

    public abstract void MakeAction();

    public abstract void TakeDamage(int damage);

}