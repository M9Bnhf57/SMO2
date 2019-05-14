using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO
{
    static class Queue
    {
        static bool Overflow { get; set; } = false;
        public static bool Empty { get; set; } = true;

        public static int Size { get; set; } = 10;
        public static int Counter { get; set; } = 0;
        public static int Losses { get; set; } = 0;

        public static Queue<Message> Messages = new Queue<Message>();

        public static List<int> StatisticSizes = new List<int>();

        static public void AddTo()
        {
            if( Counter < Size )
            {
                Messages.Enqueue(new Message());
                Messages.Last().StartTimer();
                Counter++;
                Empty = false;
            }
            else if( Counter == Size )
            {
                Overflow = true;
                Losses++;
            }
        }
        static public long GetFrom()
        {
            if( !Empty )
            {
                Messages.Peek().StopTimer();
                Counter--;
                if( Counter == 0 )
                    Empty = true;
                return Messages.Dequeue().watch.ElapsedMilliseconds;
            }
            else
            {
                return -1;
            }
        }
    }
}
