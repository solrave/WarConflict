using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public abstract class Soldier : IMakeAction
{
    public string? TeamName { get; protected init; }

    public string? Rank { get; protected init; }
    
    public int Number { get; set; }

    public bool IsAlive { get; protected set; }
    
    public abstract void MakeAction(Team friendlyTeam, Team enemTeam);

}