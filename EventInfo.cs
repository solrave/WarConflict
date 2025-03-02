namespace WarConflict;
using WarConflict.UNITS;
public enum EventType
{
    Attack, TakeHit, TakeHeal, UseAbility, Death
}

public class EventInfo : EventArgs
{
    public EventType EventType { get; }
    public string? AttackerRank { get; }
    public string? TargetRank { get; }
    public List<string>? MultipleTargetsRanks { get; }
    public string? Name { get; }
    public int? Value { get; }

    public EventInfo(EventType eventType, string? attackerRank, string? targetRank,
        List<string> multipleTargets, string? name, int? value)
    {
        EventType = eventType;
        AttackerRank = attackerRank;
        TargetRank = targetRank;
        MultipleTargetsRanks = multipleTargets;
        Name = name;
        Value = value;
    }

}