using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;
using static System.Console;

namespace WarConflict;

public class Team
{
    private readonly List<Soldier> _squad;

    public IReadOnlyList<Soldier> Squad => _squad;

    public IReadOnlyList<IMakeAction> ActionSquad => _squad;

    public IReadOnlyList<IHittable> HitSquad => _squad;
    
    public string? TeamName { get; private set; }
    
    public bool IsAlive { get; private set; }
    
    public Team(string teamName, List<Soldier> squad)
    {
        TeamName = teamName;
        _squad = squad;
        IsAlive = true;
    }

    public void RemoveDeadUnits()
    {
        _squad.RemoveAll(soldier => !soldier.IsAlive);
        CheckIfTeamAlive();
    }
    
    private void CheckIfTeamAlive()
    {
        if (_squad.Count == 0)
        {
            IsAlive = false;
        }
    }
    
}