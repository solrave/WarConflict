using WarConflict.Soldiers;
using static System.Console;

namespace WarConflict;

public class Team
{
    private static readonly Random Randomizer = new();
    private readonly MarineStats _stats = new();
    public List<ISoldier> Squad { get; set; }
    public string Name { get; }
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
        WriteLine($"Input soldiers count in team {Name}:");
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
        else WriteLine("Incorrect input!");
    }
    
    public void RemoveDead(ISoldier soldier)
    {
        Squad.Remove(soldier);
        CheckIfTeamAlive();
    }
    
    public  ISoldier PickRandomSoldier()
    {
        return Squad[Randomizer.Next(Squad.Count)];
    }
    
    private void CheckIfTeamAlive()
    {
        if (Squad.Count == 0) IsAlive = false;
    }
    
    
}