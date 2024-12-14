using WarConflict.Soldiers;
using static System.Console;

namespace WarConflict;

public class Team
{
    private readonly Random _randomizer = new();
    private readonly MarineStats _stats = new();
    public List<ISoldier> Squad { get; set; }
    public string Name { get; private set; }
    public bool IsAlive { get; private set; }
    public Team()
    {
        Squad = new List<ISoldier>();
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
        WriteLine($"Input soldiers count armed with Rifle in {Name}'s fraction:");
        bool inputOK = int.TryParse(Console.ReadLine(), out int rifleCount);
        
        if (inputOK && rifleCount > 0)
        {
            WriteLine($"Input soldiers count armed with Shotgun in {Name}'s fraction:");
            bool inputOK2 = int.TryParse(Console.ReadLine(), out int shotgunCount);
            
            if (inputOK2 && shotgunCount > 0)
            {
                for (int i = 0; i < rifleCount; i++)
                {
                    Squad.Add(new Marine(_stats.GetRifleMarineStats()));
                }

                for (int i = 0; i < shotgunCount; i++)
                {
                    Squad.Add(new Marine(_stats.GetShotgunMarineStats()));
                }
                
                foreach (var soldier in Squad)
                {
                    soldier.FractionName = Name;
                }
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
        return Squad[_randomizer.Next(Squad.Count - 1)];
    }
    
    private void CheckIfTeamAlive()
    {
        if (Squad.Count == 0) IsAlive = false;
    }
    
    
}