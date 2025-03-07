using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;

namespace WarConflict;

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
        return team.Squad[GetRandom().Next(team.Squad.Count)];
    }
    
    public static Soldier GetRandomSoldier(Team team)
    {
        return team.Squad[GetRandom().Next(team.Squad.Count)];
    }

    public static Random GetRandom()
    {
        return Randomizer;
    }

    public static void DelayAndExit()
    {
        Thread.Sleep(500);
        Environment.Exit(0);
    }
}