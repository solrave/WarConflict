// See https://aka.ms/new-console-template for more information

using WarConflict;

Team blueTeam = new();
Team redTeam = new();

BattleLogger battleLogger = new();
battleLogger.SubscribeUnits(blueTeam);
battleLogger.SubscribeUnits(redTeam);

BattleField battleField = new(blueTeam,redTeam);
battleField.StartFight();
