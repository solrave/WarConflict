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

    public static IHittable GetTargetToHit(Team team, int index)
    {
        return team.Squad.OfType<IHittable>()
            .ElementAt(index);
    }

    public static IMakeAction GetRandomSoldierForAction(Team team)
    {
        return team.Squad[GetRandom().Next(team.Squad.Count - 1)];
    }

    public static Random GetRandom()
    {
        return Randomizer;
    }
}