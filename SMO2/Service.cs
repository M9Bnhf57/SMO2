using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMO
{
    class Service
    {
        public double a { get; set; }
        public double b { get; set; }
        public bool Busy { get; set; } = false;
        static double BusyTime;

        public double Work()
        {
            Random rand = new Random();
            double R = Convert.ToDouble(rand.Next(1, 100)) / 100;
            BusyTime = (int)Math.Round(a + (b - a) * R);
            return BusyTime;
        }
    }
}

