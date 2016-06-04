using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.GameTest.Console
{
    class Coordination
    {
        public enum DirectionEnum
        {
            Up,
            Left,
            Right,
            Down
        };
        public enum ShipsEnum
        {
            Battleship = 5,
            Destroyer = 4
        };


        public struct CoordinationPointStruct
        {
            public readonly int X;
            public readonly int Y;

            public CoordinationPointStruct( int x,int y)
            {
                this.X = x;
                this.Y = y;
            }


        }

        public ShipsEnum Ship { get; set; }
        public DirectionEnum Direction { get; set; }
        public CoordinationPointStruct CoordinationStartPoint { get; set; }

        public List<CoordinationPointStruct> CoordinationLigne { get; set; }

        public bool IsAHit { get; set; }


        public Coordination()
        {
            this.CoordinationLigne = new List<CoordinationPointStruct>();
        }
     


        public void SetCoordination(char[] coord, DirectionEnum direct,ShipsEnum ship)
        {
        
            this.CoordinationStartPoint = new CoordinationPointStruct(int.Parse(coord[1].ToString()), coord[1]);

            this.Direction = direct;
            this.Ship = ship;
        }


        public bool Exists(Coordination coord,List<Coordination> coordinations)
        {
            if (coord.Ship == Console.Coordination.ShipsEnum.Battleship)
            {
                if (coordinations.Where(x => x.Ship == Console.Coordination.ShipsEnum.Battleship).ToList().Count >= 1)
                    return true;
            }
            else if(coordinations.Where(x => x.Ship == Console.Coordination.ShipsEnum.Destroyer).ToList().Count >= 2)
                return true;

            foreach (var cordination in coordinations)
            {
                if (cordination.CoordinationStartPoint.X == coord.CoordinationStartPoint.X && cordination.CoordinationStartPoint.Y == coord.CoordinationStartPoint.Y
                    && cordination.Direction == coord.Direction && cordination.Ship == coord.Ship )
                    return true;
            }


            return false;
        }

    }
}
