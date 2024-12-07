namespace WarConflict.Soldiers;

public abstract class Soldier
{
    public string Rank { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }
    public int Damage { get; protected set; }
    public bool IsAlive { get; protected set; }

    public abstract void Attack(Soldier target);
    public abstract void TakeDamage(int damage);
}