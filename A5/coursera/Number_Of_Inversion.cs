using System;

namespace inver
{
    class Program
    {
        static (long[],long) merge((long[],long) first, (long[],long) second){
            long[] merged = new long[first.Item1.Length + second.Item1.Length];
            long result = first.Item2 + second.Item2;
            int fidx =0; int sidx = 0; int i=0; long t=0; long mid = first.Item1.Length;
            while(fidx<first.Item1.Length && sidx<second.Item1.Length ){
                long f = first.Item1[fidx]; long s = second.Item1[sidx];
                if(f > s){
                    merged[i] = s; sidx++;
                    t+= mid - fidx;
                }
                else{
                    merged[i]=f; fidx++;
                }
                i++;
            }
            if(sidx == second.Item1.Length){
                for(int j=i; fidx<first.Item1.Length; j++){
                    // if(fidx<first.Item1.Length-1 && first.Item1[fidx] < first.Item1[fidx+1])
                    //     result++;
                    merged[j] = first.Item1[fidx];
                    fidx++; }
            }
            else{
                for(int j=i; sidx<second.Item1.Length; j++){
                    // if(sidx<second.Item1.Length-1 && second.Item1[sidx] < second.Item1[sidx+1])
                    //     result++;
                    merged[j] = second.Item1[sidx]; 
                    sidx++;}
                }
            return (merged, t+result);
        }

        static (long[],long) mergeSort(long start, long end, long[] array){
            if(start>=end){long[] result = {array[start]}; return (result,0); }
            long mid = (start+end)/2;
            (long[],long) half1 = mergeSort(start, mid, array);
            (long[],long) half2 = mergeSort(mid+1, end, array);
            return merge(half1, half2);
        }
        static long Solve(long n, long[] a)
        {
            return mergeSort(0, n-1, a).Item2;
        }
        static void Main(string[] args)
        {
            long n = Int64.Parse(Console.ReadLine());
            long[] result = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt64);
            Console.WriteLine(Solve(n, result));
        }
    }
}
