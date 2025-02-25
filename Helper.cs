using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;

namespace WarConflict;
using static Console;

public static class Helper
{
    private static readonly Random Randomizer = new();
    public static int GetRandomValue(int value)
    {
        return Randomizer.Next(value);
    }

    public static Soldier GetRandomTarget(Team team)
    {
        return team.Squad[Randomizer.Next(team.Squad.Count - 1)];
    }

    public static Random GetRandom()
    {
        return Randomizer;
    }
}