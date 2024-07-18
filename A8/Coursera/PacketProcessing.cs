using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
        public static long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            int packNum = arrivalTimes.Length; long time = 0; int packsIterator = 0;
            long bufferCapacity = bufferSize;
            List<Tuple<long, long>> packs = new List<Tuple<long, long>>();
            Queue<Tuple<long, long>> buffer = new Queue<Tuple<long, long>>();
            long[] result = new long[packNum];
            for(int i = 0; i < packNum; i++)
            {
                packs.Add(Tuple.Create(arrivalTimes[i], processingTimes[i]));
            } 
            for(int j = 0; j < packNum; j++)
            {
                while(buffer.Count < bufferSize && packsIterator<packNum)
                {
                    if(packs[packsIterator].Item1 >= time)
                        buffer.Enqueue(packs[packsIterator]);
                    else
                        result[packsIterator] = -1;
                    packsIterator++;
                }
                if(result[j] == -1) { continue; }
                Tuple<long, long> dequeued = buffer.Dequeue();
                time = Math.Max(time, dequeued.Item1);
                result[j] = time;
                time += dequeued.Item2;
            }
            return result.ToArray();
        }
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();
            int capacity = int.Parse(s[0]);
            int cnt = int.Parse(s[1]);
            long[] arrivalTimes = new long[cnt];
            long[] processingTimes = new long[cnt];
            for(int i=0; i<cnt; i++){
                string[] ar_pr = Console.ReadLine().Split();
                arrivalTimes[i] = Int64.Parse(ar_pr[0]);
                processingTimes[i] = Int64.Parse(ar_pr[1]);
            }
            long[] ans = Solve(capacity, arrivalTimes, processingTimes);
            foreach(var item in ans){
                Console.WriteLine(item);
            }
        }
    }
}
