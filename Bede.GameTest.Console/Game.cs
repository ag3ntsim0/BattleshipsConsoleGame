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

        public int[,] Plan { get; set; }
        


        public Game()
        {
            this.Plan = new int[GRID_NUMBER, GRID_NUMBER];
            
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


    }
}
