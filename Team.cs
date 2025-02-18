using WarConflict.Soldiers;
using static System.Console;

namespace WarConflict;

public class Team
{
    private readonly List<Soldier> _squad;

    public List<Soldier> Squad => _squad;
    
    public string? Name { get; private set; }
    
    public bool IsAlive { get; private set; }
    
    public Team()
    {
        _squad = new List<Soldier>();
        IsAlive = true;
        CreateTeam();
    }

    private void SetTeamName()
    {
        WriteLine("Input team name:");
        string? name = ReadLine();
        Name = string.IsNullOrEmpty(name) ? "Blue" : name;
    }
    
    private void CreateTeam()
    {
        SetTeamName();
        SetUnitCount(()=> new Marine(), "Marine");
        SetUnitCount(()=> new HeavyMarine(), "HeavyMarine");
        SetUnitCount(()=> new Medic(), "Medic");
        SetNumbersAndNames();
    }

    private void SetNumbersAndNames()
    {
        foreach (var soldier in _squad)
        {
            soldier.FractionName = Name;
        }

        for (int i = 0; i < _squad.Count; i++)
        {
            _squad[i].Number = i;
        }
    }
    
    private void SetUnitCount(Func<Soldier> unit, string unitRank)
    {
        WriteLine($"Input {unitRank}'s count in {Name}'s team:");
        
        bool input = int.TryParse(Console.ReadLine(), out int count);
        
        if (input && count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                _squad.Add(unit());
            }
        }
        else WriteLine("Incorrect input!");
    }
    
    private void CheckIfTeamAlive()
    {
        if (_squad.Count == 0) IsAlive = false;
    }
    
}