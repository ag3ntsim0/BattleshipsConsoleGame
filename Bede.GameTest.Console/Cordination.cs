using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.GameTest.Console
{
    class Cordination
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
            Destroyers = 4
        };

        public ShipsEnum Ship { get; set; }
        public DirectionEnum Direction { get; set; }
        public int[] Coordination { get; set; }

        public Cordination()
        {
            this.Coordination = new int[2];
        }


        public void SetCoordination(char[] cord, DirectionEnum direct,ShipsEnum ship)
        {
            this.Coordination[1] = int.Parse(cord[1].ToString());
            //cast ascii
            this.Coordination[0] = cord[1];

            this.Direction = direct;
            this.Ship = ship;
        }


        public bool Exists(Cordination cord,List<Cordination> cordinations)
        {
            if (cord.Ship == Cordination.ShipsEnum.Battleship)
            {
                if (cordinations.Where(x => x.Ship == Cordination.ShipsEnum.Battleship).ToList().Count >= 1)
                    return true;
            }
            else if(cordinations.Where(x => x.Ship == Cordination.ShipsEnum.Destroyers).ToList().Count >= 2)
                return true;

            foreach (var cordination in cordinations)
            {
                if (cordination.Coordination[0] == cord.Coordination[0] && cordination.Coordination[1] == cord.Coordination[1]
                    && cordination.Direction == cord.Direction && cordination.Ship == cord.Ship )
                    return true;
            }


            return false;
        }

    }
}
