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
        


        public Player(bool isComputerPlayer)
        {
            this.IsComputerPlayer = isComputerPlayer;


        }


        public void StartComputerProcess(Game game)
        {
            if (this.IsComputerPlayer)
            {
              
                var plan = game.Plan;

                this.Submit(ref plan,game.ComputerCoordinations);

                
                    
            }


        }


        public void Submit(ref int[,] plan,List<Coordination> coords)
        {
            do
            {
                var coord = this.RandomCordination(coords);
                if (!this.Exists(plan, coord))
                {
                    this.BuildTempPlan(ref plan, coord);
                    coords.Add(coord);
                }

            } while ((coords.Where(x => x.Ship == Coordination.ShipsEnum.Battleship).ToList().Count +
                coords.Where(x => x.Ship == Coordination.ShipsEnum.Destroyer).ToList().Count) < 3);


        }



        private bool Exists(int[,] plan, Coordination coordination)
        {
            var end = this.PlanEnd(coordination);

            if (end < Game.GRID_NUMBER && end >= 0)
            {   
                var start= coordination.CoordinationStartPoint.X;
                //x
                if (coordination.Direction == Coordination.DirectionEnum.Left || coordination.Direction == Coordination.DirectionEnum.Right)
                {
                    if (coordination.CoordinationStartPoint.X > end)
                    {
                        start = end;
                        end = coordination.CoordinationStartPoint.X;
                    }

                    for (int i = start; i <= end - 1; i++)
                    {
                        if (plan[coordination.CoordinationStartPoint.Y, i] !=0)
                            return true;
                    }



                }//y
                else {

                    start = coordination.CoordinationStartPoint.Y;

                    if (coordination.CoordinationStartPoint.Y > end)
                    {
                        start = end;
                        end = coordination.CoordinationStartPoint.Y;
                    }

                    for (int i = start; i <= end - 1; i++)
                    {
                        if (plan[i, coordination.CoordinationStartPoint.X] != 0)
                            return true;
                    }


                }
                //dosn't exists
                return false;

            }
            //out of plan
            return true;
        }


        private void BuildTempPlan(ref int[,] planTemp, Coordination coordination)
        {


            var end = this.PlanEnd(coordination);

            
            if (end < Game.GRID_NUMBER && end >= 0)
            {
                var start = coordination.CoordinationStartPoint.X;
                //x
                if (coordination.Direction == Coordination.DirectionEnum.Left || coordination.Direction == Coordination.DirectionEnum.Right)
                {
                    if (coordination.CoordinationStartPoint.X >end)
                    {
                        start = end;
                        end = coordination.CoordinationStartPoint.X;
                    }

                    for (int i = start; i <= end-1 ; i++)
                    {
                        coordination.CoordinationLigne.Add(new Coordination.CoordinationPointStruct(i,coordination.CoordinationStartPoint.Y));

                        if(coordination.Ship==Coordination.ShipsEnum.Battleship)
                            planTemp[ coordination.CoordinationStartPoint.Y,i] = Game.SIGN_BATTLESHIP;
                        else
                            planTemp[coordination.CoordinationStartPoint.Y, i] = Game.SIGN_DESTROYER;
                    }
                   


                }//y
                else {

                    start = coordination.CoordinationStartPoint.Y;

                    if (coordination.CoordinationStartPoint.Y > end)
                    {
                        start = end;
                        end = coordination.CoordinationStartPoint.Y;
                    }

                    for (int i = start; i <= end-1; i++)
                    {
                        coordination.CoordinationLigne.Add(new Coordination.CoordinationPointStruct(coordination.CoordinationStartPoint.X,i));

                        if (coordination.Ship == Coordination.ShipsEnum.Battleship)
                            planTemp[ i, coordination.CoordinationStartPoint.X] = Game.SIGN_BATTLESHIP;
                        else
                            planTemp[ i, coordination.CoordinationStartPoint.X] = Game.SIGN_DESTROYER;
                    }


                }

            }


            
        }


        public int PlanEnd(Coordination coordination)
        {
            int end=0;

            switch (coordination.Direction)
            {
                case Coordination.DirectionEnum.Left:
                    end = coordination.CoordinationStartPoint.X - (int)coordination.Ship;
                    break;
                case Coordination.DirectionEnum.Right:
                    end = coordination.CoordinationStartPoint.X + (int)coordination.Ship;
                    break;
                case Coordination.DirectionEnum.Down:
                    end = coordination.CoordinationStartPoint.Y + (int)coordination.Ship;
                    break;
                case Coordination.DirectionEnum.Up:
                    end = coordination.CoordinationStartPoint.Y - (int)coordination.Ship;
                    break;
            }

            return end;

        }



        public Coordination RandomCordination(List<Coordination> coords)
        {
         
            var random = new Random();
            Coordination coord;

            do
            {
                coord = new Coordination();

                coord.CoordinationStartPoint = new Coordination.CoordinationPointStruct(random.Next(0, 10), random.Next(0, 10));
                coord.Direction = (Coordination.DirectionEnum)random.Next(0, 4);
                coord.Ship = (Coordination.ShipsEnum)random.Next(4, 6);
                
            } while (coord.Exists(coord, coords));

            
            return coord;

        }



    }
}
