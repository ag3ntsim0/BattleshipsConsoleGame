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




        public void Submit(ref int[,] plan, List<Cordination> cordinations)
        {
            foreach (var cord in cordinations)
            {
                if (!this.Exists(plan,cord))
                    this.BuildTempPlan(ref plan, cord);
            }


        }



        private bool Exists(int[,] plan, Cordination cordination)
        {
            var end = this.PlanEnd(cordination);

            if (end < Game.GRID_NUMBER && end >= 0)
            {   
                var start= cordination.Coordination[1];
                //x
                if (cordination.Direction == Cordination.DirectionEnum.Left || cordination.Direction == Cordination.DirectionEnum.Right)
                {
                    if (cordination.Coordination[1] > end)
                    {
                        start = end;
                        end = cordination.Coordination[1];
                    }

                    for (int i = start; i <= end - 1; i++)
                    {
                        if (plan[cordination.Coordination[0], i] !=0)
                            return true;
                    }



                }//y
                else {

                    start = cordination.Coordination[0];

                    if (cordination.Coordination[0] > end)
                    {
                        start = end;
                        end = cordination.Coordination[0];
                    }

                    for (int i = start; i <= end - 1; i++)
                    {
                        if (plan[i, cordination.Coordination[1]] != 0)
                            return true;
                    }


                }

            }

            return false;
        }


        private void BuildTempPlan(ref int[,] planTemp, Cordination cordination)
        {


            var end = this.PlanEnd(cordination);

            
            if (end < Game.GRID_NUMBER && end >= 0)
            {
                var start = cordination.Coordination[1];
                //x
                if (cordination.Direction == Cordination.DirectionEnum.Left || cordination.Direction == Cordination.DirectionEnum.Right)
                {
                    if (cordination.Coordination[1] >end)
                    {
                        start = end;
                        end = cordination.Coordination[1];
                    }

                    for (int i = start; i <= end-1 ; i++)
                    {
                        if(cordination.Ship==Cordination.ShipsEnum.Battleship)
                            planTemp[ cordination.Coordination[0],i] = 1;
                        else
                            planTemp[cordination.Coordination[0], i] = 2;
                    }
                   


                }//y
                else {

                    start = cordination.Coordination[0];

                    if (cordination.Coordination[0] > end)
                    {
                        start = end;
                        end = cordination.Coordination[0];
                    }

                    for (int i = start; i <= end-1; i++)
                    {
                        if (cordination.Ship == Cordination.ShipsEnum.Battleship)
                            planTemp[ i, cordination.Coordination[1]] = 1;
                        else
                            planTemp[ i, cordination.Coordination[1]] = 2;
                    }


                }

            }


            
        }


        public int PlanEnd(Cordination cordination)
        {
            int end=0;

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
                case Cordination.DirectionEnum.Up:
                    end = cordination.Coordination[0] - (int)cordination.Ship;
                    break;
            }

            return end;

        }

    }
}
