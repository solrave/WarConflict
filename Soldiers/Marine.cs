namespace WarConflict.Soldiers;
using static Console;
using System.Threading;
public class Marine : Soldier
{
    public string Rank { get; protected set; } = "Пехотинец";
    public int MaxHealth { get; protected set; } = 60;
    public int CurrentHealth { get; protected set; }
    public int Damage { get; protected set; } = 8;
    public bool IsAlive { get; protected set; } = true;

    public Marine()
    {
        CurrentHealth = MaxHealth;
    }
    
    public override void Attack(Soldier target)
    {
        target.TakeDamage(Damage);
        WriteLine($"Солдат{Rank} нанёс {Damage} урона.");
        Thread.Sleep(1000);
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        WriteLine($"Солдат {Rank} получил {Damage} урона.");
        Thread.Sleep(1000);
        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
        if (CurrentHealth <= 0)
        {
            IsAlive = false;
            WriteLine($"Солдат {Rank} погиб!");
            Thread.Sleep(1000);
        }
    }
}