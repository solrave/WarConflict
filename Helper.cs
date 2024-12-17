using WarConflict.Soldiers;

namespace WarConflict;
using static Console;

public static class Helper
{
    private static Random _randomizer = new();
    public static int GetRandomNumber(int value)
    {
        return _randomizer.Next(value);
    }
}