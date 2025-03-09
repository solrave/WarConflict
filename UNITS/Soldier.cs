using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public abstract class Soldier : IMakeAction
{
    protected string? TeamName { get; init; }

    protected string? Rank { get; init; }
    
    public int IdNumber { get; set; }

    public bool IsAlive { get; protected set; }

    public bool IsBlind = false;
    
    public abstract void MakeAction(Team friendlyTeam, Team enemTeam);

}