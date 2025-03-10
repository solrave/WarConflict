using WarConflict;
using WarConflict.UNITS;
using static System.Console;

var random = new Random();
string teamName;
var logger = new BattleLogger();
var blueTeam = CreateTeam();
var redTeam = CreateTeam();
var battleController = new BattleController(blueTeam, redTeam, logger);

battleController.Start();
Thread.Sleep(500);
Environment.Exit(0);

void SetTeamName()
{
    WriteLine("Input team name:");
    var name = ReadLine();
    teamName = string.IsNullOrEmpty(name) ? "Team" : name;
}

Team CreateTeam()
{
    var unitList = new List<Soldier>();
    SetTeamName();
    AddUnitsToList(unitList);
    SetUnitNumbers(unitList);
    ShuffleUnits(unitList);
    return new Team(teamName, unitList);
}

void AddUnitsToList(List<Soldier> unitList)
{
    CreateUnits(unitList, () => new Marine(teamName, logger), "Marine");
    CreateUnits(unitList, () => new HeavyMarine(teamName, logger), "HeavyMarine");
    CreateUnits(unitList, () => new Medic(teamName, logger), "Medic");
}

void SetUnitNumbers(List<Soldier> unitList)
{
    for (var i = 0; i < unitList.Count; i++) unitList[i].IdNumber = i;
}

void CreateUnits(List<Soldier> unitList, Func<Soldier> unit, string unitRank)
{
    WriteLine($"Input {unitRank}'s count in {teamName}'s team:");
    var input = int.TryParse(ReadLine(), out var count);
    if (input && count >= 0)
        for (var i = 0; i < count; i++)
            unitList.Add(unit());
    else
        WriteLine("Incorrect input!");
}

void ShuffleUnits(List<Soldier> squad)
{
    for (var i = squad.Count - 1; i > 0; i--)
    {
        var j = random.Next(i + 1);
        (squad[i], squad[j]) = (squad[j], squad[i]);
    }
}