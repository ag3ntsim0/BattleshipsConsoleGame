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

    }
}
