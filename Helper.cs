using WarConflict.Soldiers;

namespace WarConflict;
using static Console;

public static class Helper
{

    private static Random _randomizer = new();
    public static int GetRandomNumber()
    {
        int maxValue = 12;
        int minValue = 0;
        return _randomizer.Next(minValue, maxValue);
    }
    
    public static void ClearConsole()
    {
        Clear();
        WriteLine("\x1b[3J");
    }
    
}