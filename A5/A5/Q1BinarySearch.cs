using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);

        public static long BinarySearch(long[] Array, long low, long high , long key)
        {
            if (high<low){
                    return -1;
            }
            int mid = (int)(low + (high-low)/2) ;
            if(key==Array[mid])
                return mid;
            else if(key < Array[mid])
                return BinarySearch(Array,low,mid-1,key);
            else
                return BinarySearch(Array,mid+1,high,key);
        }
        public static long[] Solve(long[] a, long[] b)
        {
            int size = b.Length ;
            long[] result = new long[size];
            for (int i = 0; i < size; i++){
                result[i] = BinarySearch(a, 0, a.Length-1, b[i]);
            }
            return result;
        }
    }
}


