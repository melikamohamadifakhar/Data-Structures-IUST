using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q3ParallelProcessing : Processor
    {
        public Q3ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public static Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            Queue<List<long>> threads = new Queue<List<long>>();
            for(int i = 0; i < threadCount; i++)
            {
                // List<long> item = new List<long>(){i, 0};
                // threads.Enqueue(item); 
                result.Add(new Tuple<long, long>(i, 0));
            } 
            // for(long i = threadCount; i< jobDuration.Length; i++)
            // {
            //     var thread = threads.Dequeue();
            //     List<long> newthread = new List<long>();
            //     long threadid = thread[0];
            //     long time = thread[1]+jobDuration[i-2];
            //     newthread.Add(threadid);
            //     newthread.Add(time);
            //     result.Add(new Tuple<long, long>(threadid, time));
            //     threads.Enqueue(newthread);
            // }
            return result.ToArray();
        }
    }
}
