using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public static long[] swap(long[] array, long i, long j){
            long tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
            return array;
        }
        public static (List<Tuple<long, long>>, long[]) SiftDown(long[] array, long i, List<Tuple<long, long>> result){
            long minIdx = i ; long len = array.Length;
            long left = 2*i + 1; long right = 2*i + 2;
            if(right < len && array[right]<array[minIdx]){
                minIdx = right;
            }
            if(left < len && array[left]<array[minIdx]){
                minIdx = left;
            }
            if(i != minIdx){
                swap(array, i, minIdx);
                result.Add(new (i, minIdx));
                SiftDown(array, minIdx, result);
            }
            return (result, array);
        }
        public Tuple<long, long>[] Solve(long[] array)
        {
            int len = array.Length/2-1;
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            for (int i = len ; i >= 0 ; i--)
            {
                var t = SiftDown(array, i, result);
                result = t.Item1;
                array = t.Item2;
            }
            return result.ToArray();
        }
    }
}
