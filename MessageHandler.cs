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
    
    private string AbilityName { get; }
    private int SingleDamage { get; set; }
    private List<int> Damage { get; set; }
    private bool CritApplied { get; set; }

    public MessageHandler(ISoldier attacker,string weaponName, List<ISoldier> targets, List<int> damage)
    {
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
    
    public MessageHandler(ISoldier target, int damage)
    {
        SingleTarget = target;
        SingleDamage = damage;
        SetDamageMessage();
    }

    public MessageHandler(ISoldier attacker, string abilityName, int damage)
    {
        Attacker = attacker;
        AbilityName = abilityName;
        SingleDamage = damage;
        SetUsingAbilityMessage();
    }

    private void SetRifleDamageMessage()
    {
        if (CritApplied)
        {
            _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} [{Attacker.Number}] attacks" +
                                   $" {SingleTarget.FractionName}'s {SingleTarget.Rank} [{SingleTarget.Number}] " +
                                   $"with {WeaponName} and deals CRITICAL {SingleDamage} damage!");
        }
        else
        {
            _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} [{Attacker.Number}]" +
                                   $" attacks {SingleTarget.FractionName}'s {SingleTarget.Rank}" +
                                   $" [{SingleTarget.Number}] with {WeaponName} and deals {SingleDamage} damage.");
        }
        Message = _messageBuilder.ToString();
    }

    private void SetSplashDamageMessage()
    {
        _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} [{Attacker.Number}] " +
                               $"attacks" +
                               $" with {WeaponName}.");
        Message = _messageBuilder.ToString();
    }

    private void SetDeadMessage()
    {
        _messageBuilder.Append($"{SingleTarget.FractionName}'s {SingleTarget.Rank} " +
                               $"[{SingleTarget.Number}] dies.");
        Message = _messageBuilder.ToString();
    }

    private void SetUsingAbilityMessage()
    {
        if (Attacker is Marine)
        {
            _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} [{Attacker.Number}] " +
                                   $"uses {AbilityName} and increase own damage by {SingleDamage}!");
            Message = _messageBuilder.ToString();
        }
        else if (Attacker is HeavyMarine)
        {
            _messageBuilder.Append($"{Attacker.FractionName}'s {Attacker.Rank} [{Attacker.Number}] " +
                                   $"uses {AbilityName} and gets {SingleDamage} defence!");
            Message = _messageBuilder.ToString();
        }
    }

    private void SetDamageMessage()
    {
        _messageBuilder.Append($"{SingleTarget.FractionName}'s {SingleTarget.Rank} [{SingleTarget.Number}] " +
                               $"gets {SingleDamage} damage.");
        Message = _messageBuilder.ToString();
    }
}