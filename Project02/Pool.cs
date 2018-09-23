using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Project02
{
    class Pool
    {
        private Location loc;
        private Temperature temp;
        private String poolLetter;
        public static int poolCount = 0;

        public Pool(String pName, int x, int y)
        {
            poolLetter = pName;
            loc = new Location(x, y);
            temp = new Temperature();
            poolCount++;
        }

        public Pool(String pName, Location l)
        {
            poolLetter = pName;
            loc = l;
            temp = new Temperature();
            poolCount++;
        }

        public static String NearestDistance(Pool[] pools, int[,] myArray, ref int one, ref int two)
        {
            double dist = 0;
            double nearest = 1000;
            double[] distanceArray = new double[7];
            int[,] nearestPoints = new int[1, 2];
            nearestPoints[0, 0] = one;
            nearestPoints[0, 1] = two;
            string orderString = "";

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    dist = Location.Distance(myArray[i, j], myArray[i, j + 1], one, two);
                    distanceArray[i] = dist;

                    if (dist < nearest)
                    {
                        nearest = dist;
                    }
                }
            }

            for(int k = 0; k < 7; k++)
            {
                if (nearest == distanceArray[k])
                {
                    orderString += pools[k].ToString(); // adds the pool to the display string
                    one = myArray[k, 0]; // sets the starting pool for the next iteration
                    two = myArray[k, 1];
                    myArray[k, 0] = 5000;
                    myArray[k, 1] = 5000;
                }
            }
            
            return orderString;
        }

        public override string ToString()
        {
            return "\nPool " + poolLetter + ":\n" + loc.ToString() + "\n" + temp.ToString() + "\n";
        }

        ~Pool() { }
    }
}
