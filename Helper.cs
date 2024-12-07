namespace WarConflict;
using static Console;
public static class Helper
{
    private static Random _randomizer = new Random();
    
    public static void ClearConsole()
    {
        Clear();
        WriteLine("\x1b[3J");
    }
    
    public static int PickRandomSoldier(Team team)
    {
        return _randomizer.Next(0, team.Squad.Count);
    }
}