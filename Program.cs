// See https://aka.ms/new-console-template for more information

using WarConflict;

Team blueTeam = new Team("Blue");
Team redTeam = new Team("Red");
Battlefield battleGround = new Battlefield(blueTeam,redTeam);
battleGround.StartFight();
