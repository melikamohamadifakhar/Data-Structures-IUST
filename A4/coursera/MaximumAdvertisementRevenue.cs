using System;
using System.Collections.Generic;
namespace MaximumAdvertisementRevenue
{
    class Program
    {
        static long MaxRevenue(long[] array1, long[] array2, int num){
            long maxReven=0;
            Array.Sort(array1); Array.Sort(array2);
            for (int i=0; i<num; i++)
                maxReven += (array1[i]*array2[i]);
            return maxReven;
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            long[] array1 = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt64);
            long[] array2 = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt64);
            Console.WriteLine(MaxRevenue(array1, array2, num));
        }
    }
}
