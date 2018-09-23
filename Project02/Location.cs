using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Project02
{
    class Location
    {
        private int xCoordinate;
        private int yCoordinate;

        public Location()
        {
            xCoordinate = 0;
            yCoordinate = 0;
        }

        public Location(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
        }

        public int XCoordinate
        {
            get { return this.xCoordinate; }
            set { this.xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return this.yCoordinate; }
            set { this.yCoordinate = value; }
        }

        public static double Distance(int x1, int y1, int x2, int y2)
        {
            double xDist = x1 - x2;
            double yDist = y1 - y2;

            double dist = Math.Sqrt(xDist * xDist + yDist * yDist);
            return dist;
        }

        public override string ToString()
        {
            return "Location: (" + (xCoordinate + 92) / 80 + "," + (yCoordinate + 92) / 80 + ")";
        }

        ~Location() { }
    }
}
