using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        static long[] merge(long[] first, long[] second){
            long[] merged = new long[first.Length + second.Length];
            int fidx =0; int sidx =0; int i=0;
            while(fidx<first.Length && sidx<second.Length ){
                long f = first[fidx]; long s = second[sidx];
                if(f > s){
                    merged[i] = s; sidx++;
                }
                else{
                    merged[i]=f; fidx++;
                }
                i++;
            }
            if(sidx == second.Length){
                for(int j=i; fidx<first.Length; j++){
                    merged[j] = first[fidx];
                    fidx++; }
            }
            else{
                for(int j=i; sidx<second.Length; j++){
                    merged[j] = second[sidx]; 
                    sidx++;}
                }
            return merged;
        }

        public long[] mergeSort(long start, long end, long[] array){
            if(start>=end){long[] result = {array[start]}; return result; }
            long mid = (start+end)/2;
            long[] half1 = mergeSort(start, mid, array);
            long[] half2 = mergeSort(mid+1, end, array);
            return merge(half1, half2);
        }
        public long[] Solve(long n, long[] a)
        {
            return mergeSort(0, n-1, a);
        }
    }
}
