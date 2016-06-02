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

            
            var player = new Player(false);
            var plan=player.BuildTempPlan(new Cordination() { Coordination = new int[2] { 6 ,1 }, Direction = Cordination.DirectionEnum.Top, Ship = Cordination.ShipsEnum.Destroyers });
            new Game().DisplayPlan(plan);

            System.Console.ReadKey();
        }
    }
}
