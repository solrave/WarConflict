using WarConflict;
using WarConflict.UNITS;
using static System.Console;

string teamName;
var logger = new BattleLogger();
var blueTeam = CreateTeam();
var redTeam = CreateTeam();
var  battleController = new BattleController(blueTeam, redTeam, logger);

battleController.StartFight();


void SetTeamName()
{
    WriteLine("Input team name:");
    string? name = ReadLine();
    teamName = string.IsNullOrEmpty(name) ? "Team" : name;
}
    
Team CreateTeam()
{
    var unitList = new List<Soldier>();
    SetTeamName();
    AddUnitsToList(unitList);
    SetUnitNumbers(unitList);
    return new Team(teamName, unitList);
}

void AddUnitsToList(List<Soldier> unitList)
{
    CreateUnits(unitList,()=> new Marine(teamName, logger), "Marine");
    CreateUnits(unitList, ()=> new HeavyMarine(teamName, logger), "HeavyMarine");
    CreateUnits(unitList, ()=> new Medic(teamName, logger), "Medic");
}

void SetUnitNumbers(List<Soldier> unitList)
{
    for (int i = 0; i < unitList.Count; i++)
    {
        unitList[i].Number = i;
    }
}
    
void CreateUnits(List<Soldier> unitList, Func<Soldier> unit, string unitRank)
{
    WriteLine($"Input {unitRank}'s count in {teamName}'s team:");
        
    bool input = int.TryParse(ReadLine(), out int count);
        
    if (input && count >= 0)
    {
        for (int i = 0; i < count; i++)
        {
            unitList.Add(unit());
        }
    }
    else WriteLine("Incorrect input!");
}