using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
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
    }
}