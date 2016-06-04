using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.GameTest.Console
{
    class Game
    {
        public const int GRID_NUMBER=10;
        public const int SIGN_BATTLESHIP = 1;
        public const int SIGN_DESTROYER = 2;
        public const int HIT_BATTLESHIP = 9;
        public const int HIT_DESTROYER = 8;

        public int[,] Plan { get; set; }
        public List<Coordination> ComputerCoordinations { get; set; }

        public Game()
        {
            this.Plan = new int[GRID_NUMBER, GRID_NUMBER];
            this.ComputerCoordinations = new List<Coordination>();
        }


        public int[,] Init(int[,] plan)
        {
            for (int i = 0; i < GRID_NUMBER; i++)
            {
                for (int j = 0; j < GRID_NUMBER; j++)
                {
                    plan[i, j] = 0;
                }
            }

            return plan;
        }


        public void DisplayPlan(int[,] plan)
        {
            for (int i = 0; i < GRID_NUMBER; i++)
            {
                for (int j = 0; j < GRID_NUMBER; j++)
                {
                    System.Console.Write(plan[i,j]);

                }
                System.Console.Write("\n");
            }

        }


        public Coordination CheckHit(ref int[,] plan,Coordination coord)
        {
            //check if there's any valid point
            if (this.ComputerCoordinations.Any(
                x =>
                    x.CoordinationLigne.Any(
                        y =>
                            y.X == coord.CoordinationStartPoint.X && y.Y == coord.CoordinationStartPoint.Y
                    )
                ))
            {
                plan[ coord.CoordinationStartPoint.Y,coord.CoordinationStartPoint.X] = (coord.Ship == Coordination.ShipsEnum.Battleship) ? HIT_BATTLESHIP : HIT_DESTROYER;

                 var coordResponse=this.ComputerCoordinations.First(
                                     x =>
                                            x.CoordinationLigne.Any(
                                                y =>
                                                    y.X == coord.CoordinationStartPoint.X && y.Y == coord.CoordinationStartPoint.Y
                                            )
                                        );
                coordResponse.IsAHit = this.IsSinking(coordResponse);
                return coordResponse;   
            }

            return null;


        }




        public bool IsSinking(Coordination coordComputer)
        {
            foreach (var coord in coordComputer.CoordinationLigne)
            {
                if (coordComputer.Ship == Coordination.ShipsEnum.Battleship)
                {
                    if (this.Plan[coord.Y, coord.X] != HIT_BATTLESHIP)
                        return false;
                }
                else
                {
                    if (this.Plan[coord.Y, coord.X] != HIT_DESTROYER)
                        return false;
                }
            }

            return true;
        }


    }
}
