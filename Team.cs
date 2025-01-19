using WarConflict.Soldiers;
using static System.Console;

namespace WarConflict;

public class Team
{
    private readonly Random _randomizer = new();
    
    private readonly MarineStats _stats = new();

    private List<ISoldier> _squad;

    public IReadOnlyList<ISoldier> Squad => _squad;
    
    public string Name { get; private set; }
    
    public bool IsAlive { get; private set; }
    
    public Team()
    {
        _squad = new List<ISoldier>();
        IsAlive = true;
        CreateSquad();
    }

    private void CreateSquad()
    {
        SetSquadName();
        SetSoldiers();
    }

    private void SetSquadName()
    {
        WriteLine("Input fraction's name:");
        string name = ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Name = "Blue";
        }
        else Name = name;
    }
    
    private void SetSoldiers()
    {
        SetMarinesCount();
        SetHeavyMarinesCount();
        SetMedicsCount();
    }

    private void SetNaumbersAndNames()
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
    
    private void SetMedicsCount()
    {
        WriteLine($"Input Medic's count in {Name}'s fraction:");
        bool input = int.TryParse(Console.ReadLine(), out int count);
        
        if (input && count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                _squad.Add(new Medic(_stats.GetMedicStats()));
            }
        }
        else WriteLine("Incorrect input!");
        SetNaumbersAndNames();
    }

    private void SetHeavyMarinesCount()
    {
        WriteLine($"Input HeavyMarine's count armed with Shotgun in {Name}'s fraction:");
        bool input = int.TryParse(Console.ReadLine(), out int count);
        
        if (input && count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                _squad.Add(new HeavyMarine(_stats.GetHeavyMarineStats()));
            }
        }
        else WriteLine("Incorrect input!");
        SetNaumbersAndNames();
    }
    
    private void SetMarinesCount()
    {
        WriteLine($"Input Marine's count armed with Rifle in {Name}'s fraction:");
        bool input = int.TryParse(Console.ReadLine(), out int count);
        
        if (input && count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                _squad.Add(new Marine(_stats.GetRifleMarineStats()));
            }
        }
        else WriteLine("Incorrect input!");
        SetNaumbersAndNames();
    }
    
    public void RemoveDead(ISoldier soldier)
    {
        _squad.Remove(soldier);
        CheckIfTeamAlive();
    }
    
    public  ISoldier PickRandomSoldier()
    {
        return _squad[_randomizer.Next(_squad.Count - 1)];
    }
    
    private void CheckIfTeamAlive()
    {
        if (_squad.Count == 0) IsAlive = false;
    }
    
    
}