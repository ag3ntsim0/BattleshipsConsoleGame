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



        //private bool Exists(int[,] plan, Cordination cordination)
        //{
        //    for (int i = 0; i < Game.GRID_NUMBER; i++)
        //    {
        //        for (int j = 0; j < Game.GRID_NUMBER; j++)
        //        {
        //            if(plan[i, j]== cordination.)
        //        }
        //    }

        //}


        public int[,] BuildTempPlan(Cordination cordination)
        {

            int[,] planTemp = new int[Game.GRID_NUMBER, Game.GRID_NUMBER];
            int end = 0;

            switch (cordination.Direction)
            {
                case Cordination.DirectionEnum.Left:
                    end = cordination.Coordination[1] - (int)cordination.Ship;
                    break;
                case Cordination.DirectionEnum.Right:
                    end = cordination.Coordination[1] + (int)cordination.Ship;
                    break;
                case Cordination.DirectionEnum.Down:
                    end = cordination.Coordination[0] + (int)cordination.Ship;
                    break;
                case Cordination.DirectionEnum.Top:
                    end = cordination.Coordination[0] - (int)cordination.Ship;
                    break;
            }


            if (end < Game.GRID_NUMBER && end >= 0)
            {   //x
                if (cordination.Direction == Cordination.DirectionEnum.Left || cordination.Direction == Cordination.DirectionEnum.Right)
                {
                    if (cordination.Coordination[1] >end)
                    {
                        var temp = end;
                        end = cordination.Coordination[1];
                        cordination.Coordination[1] = temp;
                    }

                    for (int i = cordination.Coordination[1]; i <= end-1 ; i++)
                    {
                        planTemp[ cordination.Coordination[0],i] = 1;
                    }
                   


                }//y
                else {

                    if (cordination.Coordination[0] > end)
                    {
                        var temp = end;
                        end = cordination.Coordination[0];
                        cordination.Coordination[0] = temp;
                    }

                    for (int i = cordination.Coordination[0]; i <= end-1; i++)
                    {
                        planTemp[ i,cordination.Coordination[1]] = 1;
                    }


                }

            }



            return planTemp;
        }




    }
}
