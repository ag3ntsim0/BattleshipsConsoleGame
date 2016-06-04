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

            //init
            var player = new Player(true);

            var game = new Game();
            player.StartComputerProcess(game);
            
            //read cordination from user

            game.DisplayPlan(game.Plan);

            var userCoord = new List<Coordination>();

            do
            {
                System.Console.WriteLine("Please insert your Target Coordination");


            } while (userCoord.Count<=(Game.GRID_NUMBER*Game.GRID_NUMBER));

            System.Console.WriteLine("Please insert any Key to exit");
            System.Console.ReadKey();
        }
    }
}
