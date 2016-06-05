using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Loading...");

            player.StartComputerProcess(game);
            
            //read coordination from user
            
            
            /* Uncomment to see the result
            game.DisplayPlan(game.Plan);
            */
            var userCoordinations = new List<Coordination.CoordinationPointStruct>();

            do
            {
                System.Console.ResetColor();
                System.Console.WriteLine("Please insert your Target Coordination");
                var input = System.Console.ReadLine();
                if (Regex.IsMatch(input, @"^[A-J]{1}([1-9]|10){1}$"))
                {
                    Coordination.CoordinationPointStruct coord = new Coordination.CoordinationPointStruct(int.Parse(input.Substring(1, input.Length - 1)), (char)input[0]);
                    System.Console.ResetColor();

                    if (!userCoordinations.Any(
                            x =>
                                x.X == coord.X && x.Y == coord.Y))
                    {
                        userCoordinations.Add(coord);

                        var plan = game.Plan;
                        var resultCoord = game.CheckHit(ref plan, coord);

                        if (resultCoord != null)
                        {

                            if (resultCoord.IsAHit)
                            {
                                System.Console.ForegroundColor = ConsoleColor.Green;
                                System.Console.WriteLine($"WoW ! the {resultCoord.Ship.ToString()} is Sinking ");
                            }
                            else
                            {
                                System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                                System.Console.WriteLine($"You have Hit a {resultCoord.Ship.ToString()}");
                            }

                        }
                        else
                        {
                            System.Console.ForegroundColor = ConsoleColor.Yellow;
                            System.Console.WriteLine("OPS , Target Missed ! Try again...");
                        }



                    }
                    else
                    {
                        System.Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.WriteLine("You have already used this Coordination ! Try another one...");
                    }
                        

                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Invalid input !");
                }



                /* Uncomment to see the result
                game.DisplayPlan(game.Plan);
                */

            } while (game.ComputerCoordinations.Where(x=> x.IsAHit).ToList().Count< (Game.NUMBER_BATTLESHIP+Game.NUMBER_DESTROYER)  );

            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("*********************************");
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("Congratulation you'r the Winner :D");
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("*********************************");
            System.Console.ResetColor();
            System.Console.WriteLine("Press any Key to exit");
            System.Console.ReadKey();
        }
    }
}
