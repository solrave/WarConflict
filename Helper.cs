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
        return team.Squad[Randomizer.Next(team.Squad.Count)];
    }

    public static T GetRandomSoldier<T>(IReadOnlyList<T> squad)
    {
        return squad[Randomizer.Next(squad.Count)];
    }
}