using WarConflict.Soldiers;

namespace WarConflict;
using static Console;
public static class Helper
{
    private static readonly Random Randomizer = new();
    public static ISoldier PickRandomSoldier(Team team)
    {
        return team.Squad[Randomizer.Next(0, team.Squad.Count - 1)];
    }

    public static int PickSoldierByIndex(Team team)
    {
        return Randomizer.Next(0, team.Squad.Count - 1);
    }
    
    public static void ClearConsole()
    {
        Clear();
        WriteLine("\x1b[3J");
    }
    
    

    
}