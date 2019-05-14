using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SMO
{
    class Message
    {
        public Stopwatch watch;
        public static List<long> EachMessageTimeInQueue = new List<long>();

        public void StartTimer()
        {
            watch = Stopwatch.StartNew();
        }
        public void StopTimer()
        {
            watch.Stop();
            EachMessageTimeInQueue.Add(watch.ElapsedMilliseconds);
        }
    }
}
