using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.GameTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var player = new Player(true);
            //var cordinations = new List<Cordination>() {
            //    new Cordination() { Coordination = new int[2] { 2, 3 }, Direction = Cordination.DirectionEnum.Right, Ship = Cordination.ShipsEnum.Destroyers },
            //    new Cordination() { Coordination = new int[2] { 6 ,1 }, Direction = Cordination.DirectionEnum.Up, Ship = Cordination.ShipsEnum.Destroyers },
            //    new Cordination() { Coordination = new int[2] { 5 ,9 }, Direction = Cordination.DirectionEnum.Up, Ship = Cordination.ShipsEnum.Battleship }
            //};
            var game = new Game();
            //game.Cordinations = cordinations;

            player.StartComputerProcess(game);
            game.DisplayPlan(game.Plan);

            System.Console.ReadKey();
        }
    }
}
