namespace WarConflict;
using Soldiers;
using System.Text;

public class MessageHandler
{
    public string Message { get; private set; }

    private StringBuilder _messageBuilder = new StringBuilder();
    private ISoldier Attacker { get; set; }
    private ISoldier SingleTarget { get; set; }
    private List<ISoldier> Targets { get; set; }
    private string WeaponName { get; set; }
    private int SingleDamage { get; set; }
    private List<int> Damage { get; set; }
    private bool CritApplied { get; set; }

    public MessageHandler(ISoldier attacker,string weaponName, List<ISoldier> targets, List<int> damage)
    {
        //Targets = new List<ISoldier>();
       // Damage = new List<int>();
        Attacker = attacker;
        WeaponName = weaponName;
        Targets = targets;
        Damage = damage;
        SetSplashDamageMessage();
    }

    public MessageHandler(ISoldier attacker,string weaponName, ISoldier target, int damage, bool critDamage)
    {
        Attacker = attacker;
        WeaponName = weaponName;
        SingleTarget = target;
        SingleDamage = damage;
        CritApplied = critDamage;
        SetRifleDamageMessage();
    }

    public MessageHandler(ISoldier target)
    {
        SingleTarget = target;
        SetDeadMessage();
    }

    private void SetRifleDamageMessage()
    {
        if (CritApplied)
        {
            _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} attacks" +
                                   $" {SingleTarget.FractionName}'s {SingleTarget.Rank} " +
                                   $"with {WeaponName} and deals CRITICAL {SingleDamage} damage!");
        }
        else
        {
            _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} attacks" +
                                   $" {SingleTarget.FractionName}'s {SingleTarget.Rank} " +
                                   $"with {WeaponName} and deals {SingleDamage} damage.");
        }
        Message = _messageBuilder.ToString();
    }

    private void SetSplashDamageMessage()
    {
        _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} attacks" +
                               $" with {WeaponName}.");
        for (int i = 0; i < Targets.Count; i++)
        {
            _messageBuilder.Append($"\n{Targets[i].FractionName}'s {Targets[i].Rank} " +
                                       $"gets {Damage[i]} splash damage.");
            
        }
        Message = _messageBuilder.ToString();
    }

    private void SetDeadMessage()
    {
        _messageBuilder.Append($"{SingleTarget.FractionName}'s {SingleTarget.Rank} dies.");
        Message = _messageBuilder.ToString();
    }
    
}