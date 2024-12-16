using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public class Medic : ISoldier
{
    private const int AbilityChance = 6;
    
    public event Action<MessageHandler>? AttackInfo;
    
    public int Armor { get; private set; }
    
    private string _abilityName = "MedKit";
    
    public IWeapon Weapon { get; }
    
    public int Number { get; set; }
    
    public string FractionName { get; set; }
    
    public string Rank { get; }
    
    public bool IsAlive { get; set; }
    
    public void Attack(Team team)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        int hpLeft = Armor - damage;
        if (hpLeft <= 0) Armor = 0;
        else Armor -= damage;
        if (Armor == 0)
        {
            IsAlive = false;
        }
        AttackInfo?.Invoke(new MessageHandler(this, damage));
    }
    
    private void UseAbility()
    {
        if (TryUseAbility())
        {
            AttackInfo?.Invoke(new MessageHandler(this, _abilityName));
        }
    }

    private bool TryUseAbility()
    { 
        int abilityActual = Helper.GetRandomNumber();
        if (AbilityChance > abilityActual)
        {
            return true;
        }

        return false;
    }
}