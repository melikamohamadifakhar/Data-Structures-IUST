using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            return quickSort(a,0,a.Length-1);
        }
        public static long[] quickSort(long[] array , long l , long r){
            if (l>=r)
                return array ;
            (long,long) t = Partition(array,l,r);
            
            return quickSort(quickSort(array,l,t.Item1-1),t.Item2+1,r);
            }
        public static (long,long) Partition(long[] array , long l , long r)
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
    }
}
