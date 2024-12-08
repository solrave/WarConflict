using WarConflict.Soldiers;
using static System.Console;

namespace WarConflict;

public class Team
{
    private readonly MarineStats _stats = new();
    public List<ISoldier> Squad { get; set; }
    private string Name { get; set; }
    public bool IsAlive { get; private set; }
    public Team(string name)
    {
        Squad = new List<ISoldier>();
        Name = name;
        IsAlive = true;
        SetSoldierQuantity();
    }

    public void SetSoldierQuantity()
    {
        WriteLine($"Укажите кол-во бойцов в команде {Name}:");
        bool isCorrect = int.TryParse(Console.ReadLine(), out int count);
        if (isCorrect && count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                Squad.Add(new Marine(_stats.GetMarineStats()));
            }

            foreach (var soldier in Squad)
            {
                soldier.FractionName = Name;
            }
        }
        else WriteLine("Введено некорректное значение!");
    }

    public void KillSoldierByIndex(int index)
    {
        Squad.RemoveAt(index);
        CheckIfTeamAlive();
    }
    
    public void CheckIfSoldierDead(ISoldier soldier)
    {
        if (!soldier.IsAlive) Squad.Remove(soldier);
            CheckIfTeamAlive();
    }
    
    private void CheckIfTeamAlive()
    {
        if (Squad.Count <= 0) IsAlive = false;
    }
}