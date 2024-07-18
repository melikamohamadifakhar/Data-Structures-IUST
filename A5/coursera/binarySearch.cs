using System;

namespace binarySearch
{
    class Program
    {
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
        static long[] Solve(long[] a, long[] b){
            int size = b.Length ;
            long[] result = new long[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = BinarySearch(a, 0, a.Length - 1,b[i]);
            }
            return result;
        }
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();

            string str1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string str2 = Console.ReadLine();

            long[] a = Array.ConvertAll(str1.Split(), Convert.ToInt64);

            long[] b = Array.ConvertAll(str2.Split(), Convert.ToInt64);

            long[] result = Solve(a,b);

            foreach(var res in result)

            {

            Console.Write($"{res} ");

            }
        }
    }
}
