using WarConflict.UNITS.Interfaces;

namespace WarConflict.UNITS;

public abstract class Soldier : IMakeAction, IHittable
{
    public bool IsBlind = false;
    protected string? TeamName { get; init; }

    protected string? Rank { get; init; }

    public int IdNumber { get; set; }

    public bool IsAlive { get; protected set; }

    public abstract void TakeHit(int damageValue);

    public abstract void MakeAction(Team friendlyTeam, Team enemTeam);
}