// See https://aka.ms/new-console-template for more information

using WarConflict;
using WarConflict.Soldiers;

Team blueTeam = new Team();
Team redTeam = new Team();
Battlefield battleGround = new Battlefield(blueTeam,redTeam);
battleGround.StartFight();
