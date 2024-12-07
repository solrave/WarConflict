// See https://aka.ms/new-console-template for more information

using WarConflict;

Team blueTeam = new Team("Синяя");
Team redTeam = new Team("Красная");
blueTeam.SetSoldierQuantity();
redTeam.SetSoldierQuantity();
Battlefield battleGround = new Battlefield(blueTeam,redTeam);
battleGround.StartFight();
