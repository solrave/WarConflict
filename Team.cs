using WarConflict.Soldiers;
using static System.Console;

namespace WarConflict;

public class Team
{
    public List<Soldier> Squad { get; set; }
    private string Color { get; set; }
    public bool IsAlive { get; private set; }
    public Team(string color)
    {
        Squad = new List<Soldier>();
        Color = color;
        IsAlive = true;
    }

    public void SetSoldierQuantity()
    {
        WriteLine($"Укажите кол-во бойцов в команде {Color}:");
        bool isCorrect = int.TryParse(Console.ReadLine(), out int count);
        if (isCorrect && count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                Squad.Add(new Marine());
            }
        }
        else WriteLine("Введено некорректное значение!");
    }

    public void KillSoldierByIndex(int index)
    {
        Squad.RemoveAt(index);
        CheckIfTeamAlive();
    }
    
    public void CheckForDeadSoldiers()
    {
        for (int i = 0; i < Squad.Count; i++)
        {
            if (!Squad[i].IsAlive)
            {
                Squad.RemoveAt(i);
            }
        }
        CheckIfTeamAlive();
    }
    
    private void CheckIfTeamAlive()
    {
        if (Squad.Count <= 0) IsAlive = false;
    }
}