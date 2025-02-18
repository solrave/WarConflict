using WarConflict.UNITS.Interfaces;
using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public class Medic : Soldier, IHealer
{
    public int Armor { get; private set; }
    
    public override event Action<EventArgs> OnAction;
    
    public override event Action<EventArgs> OnDead;
    
    public Medic()
    {
        Rank = "Medic";
        Armor = 5;
        IsAlive = true;
    }

    public override void MakeAction()
    {
        throw new NotImplementedException();
    }

    public override void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public void Heal(Team team)
    {
        throw new NotImplementedException();
    }
}
