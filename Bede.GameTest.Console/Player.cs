using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.GameTest.Console
{
    class Player
    {


        public bool IsComputerPlayer { get; set; }
        public List<Cordination> Cordinations { get; set; }


        public Player(bool isComputerPlayer)
        {
            this.IsComputerPlayer = isComputerPlayer;


        }




        public void Submit(ref int[,] plan, Cordination cordination)
        {


            for (int i = 0; i < Game.GRID_NUMBER; i++)
            {
                for (int j = 0; j < Game.GRID_NUMBER; j++)
                {
                    //must insert test
                    plan[i, j] = 1;
                }
            }
            

        }



        private bool Exists(int[,] plan, Cordination cordination)
        {
            for (int i = 0; i < Game.GRID_NUMBER; i++)
            {
                for (int j = 0; j < Game.GRID_NUMBER; j++)
                {
                    if(plan[i, j]== cordination.)
                }
            }

        }


        private int[,] BuildTempPlan(Cordination cordination)
        {

            int[,] planTemp = new int[Game.GRID_NUMBER, Game.GRID_NUMBER];
            int end = 0;

            switch (cordination.Direction)
            {
                case Cordination.DirectionEnum.Left:
                    end = cordination.Coordination[1] - int.Parse(cordination.Ship.ToString());
                    break;
                case Cordination.DirectionEnum.Right:
                    end = cordination.Coordination[1] + int.Parse(cordination.Ship.ToString());
                    break;
                case Cordination.DirectionEnum.Down:
                    end = cordination.Coordination[0] + int.Parse(cordination.Ship.ToString());
                    break;
                case Cordination.DirectionEnum.Top:
                    end = cordination.Coordination[0] - int.Parse(cordination.Ship.ToString());
                    break;
            }

            if (end < Game.GRID_NUMBER && end >= 0)
            {
                if (cordination.Coordination[0] == i && cordination.Coordination[1] == j)
                {
                    if(end>)
                    for (int i = 0; i < Game.GRID_NUMBER; i++)
                    {

                    }
                }
                
            }



            return planTemp;
        }




    }
}
