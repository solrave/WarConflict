namespace WarConflict.UNITS.Interfaces;

public interface IAbility
{
    public int AbilityChance { get; set; }
    
    public string AbilityName { get; set; }
    
    public void Ability();

}