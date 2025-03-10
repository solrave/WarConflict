namespace WarConflict;

public static class Helper
{
    private static readonly Random Randomizer = new();

    public static int GetRandomValue(int value)
    {
        return Randomizer.Next(value);
    }

    public static T GetRandomSoldier<T>(IReadOnlyList<T> squad)
    {
        return squad[Randomizer.Next(squad.Count)];
    }
}