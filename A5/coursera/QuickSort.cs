using System;

namespace quickSort
{
    class Program
    {

        public static readonly char[] IgnoreChars = new char[] { '\n', '\r', ' ' };

        static long[] Solve(long n, long[] a)
        {
            return quickSort(a,0,a.Length-1);
        }
        static long[] quickSort(long[] array , long l , long r){
            if (l>=r)
                return array ;
            (long,long) t = Partition(array,l,r);
            
            return quickSort(quickSort(array,l,t.Item1-1),t.Item2+1,r);
            }
        static (long,long) Partition(long[] array , long l , long r)
        {
            long pivot = array[l];
            long i = l ;
            long j = l ;
            long k = r ;
            while(i<=k)
            {
                if (array[i] < pivot )
                {
                    long tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp ;
                    i += 1 ;
                    j += 1 ;
                }
                else if (array[i] > pivot )
                {
                    long tmp = array[i];
                    array[i] = array[k];
                    array[k] = tmp ;
                    k--;
                }
                else
                    i++;
            }
            return (j,k) ;
        }
        static void Main(string[] args)
        {
            long n = Int64.Parse(Console.ReadLine());
            var long_args = new long[n];
            for (long i = 0; i < n; i++)
            {
                long_args[i] = Int64.Parse(Console.ReadLine());
            }
            var result = Solve(n, long_args);
            foreach(var i in  result){
                System.Console.Write($"{i} ");
            }
        }
    }
}