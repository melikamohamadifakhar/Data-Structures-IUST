using System;
using System.Collections.Generic;
using System.Collections;
namespace OrganizingLottery
{
    class Program
    {
        class segment : IComparer<segment>{
            public long n {get; set;}
            public bool isEnd {get; set;}
            public segment(){}
            public segment(long N, bool IsEnd){
                n = N; isEnd = IsEnd;
            }
    public int Compare(segment x, segment y)
    {
    return (new CaseInsensitiveComparer()).Compare((x).n, ((y).n));
    }

        }
        static long BinarySearch(segment[] Array, long low, long high , long key)
        {
            if (high<low){
                    return high;
            }
            int mid = (int)(low + (high-low)/2) ;
            if(key==Array[mid].n)
                return mid;
            else if(key < Array[mid].n)
                return BinarySearch(Array,low,mid-1,key);
            else
                return BinarySearch(Array,mid+1,high,key);
        }
        static long[] lottery(segment[] segments, long[] point){
            long[] result = new long[segments.Length];
            for (int i = 0; i < point.Length; i++){
                long idx = BinarySearch(segments, 0, segments.Length-1, point[i]);
                long scount=0; long ecount=0;
                for(int j=0; j<=idx; j++){
                    if(segments[i].isEnd)
                        ecount++;
                    else
                        scount++;
                }
                result[i] = scount-ecount;
            }
            return result;
        }
        static long[] Solve(long[] points, long[] startSegment, long[] endSegment)
        {
            int j = 2 * startSegment.Length; int k=0;
            segment[] segments = new segment[j];
            for(int i=0; i<j; i++){
                segments[i] = new segment(startSegment[k], false);
                segments[i+1] = new segment(endSegment[k], true);
                k++;
            }
            // Array.Sort(segments, s);
            // segment[] sorted = segments.OrderBy(c => c.n).ToArray();
            Array.Sort(segments, new segment());
            // segment[] sorted = segments.OrderBy(s => s.n);
            return lottery(segments, points);
        }
        static void Main(string[] args)
        {
            long[] point = {4, 7, 2};
            long[] s = {1, 0, 7, 6};
            long[] e = {3, 5, 23, 12};
            long[] result = Solve(point, s, e);
            foreach (var i in result)
            Console.WriteLine(result);
        }
    }
}

