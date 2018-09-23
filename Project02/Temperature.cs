using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project02
{
    class Temperature
    {
        private double degree;
        private String scale;

        Random rand = new Random(Guid.NewGuid().GetHashCode());

        public Temperature()
        {
            degree = rand.NextDouble() * 6 + 98;
            scale = " °F";
        }

        public override string ToString()
        {
            return "Temperature: " + Math.Round(degree, 2) + scale;
        }

        ~Temperature() { }
    }
}
