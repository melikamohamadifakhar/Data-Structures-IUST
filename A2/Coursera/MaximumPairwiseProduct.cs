using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Pairwise_Product
{
    class Program
    {
        static long MaximumPairwiseProduct1(long[] Nums){
            long Max=0;
            for (int i=0; i < Nums.Length; i++)
                for (int j=0; j< Nums.Length; j++)
                    if ((Nums[i] * Nums[j] > Max) )
                        Max = Nums[i] * Nums[j];
            return Max;
}
        static long MaximumPairwiseProduct(long[] Nums){
            int MaxIdx1 = -1;
            for (int i = 0; i < Nums.Length; i++){
                if(MaxIdx1==-1 || Nums[i]>Nums[MaxIdx1]){
                    MaxIdx1=i;
                }
            }
            int MaxIdx2 = -1;
            for (int j = 0; j < Nums.Length; j++){
                if(j != MaxIdx1 && (MaxIdx2 == -1 || Nums[j]> Nums[MaxIdx2])){
                    MaxIdx2=j;
                }
            }
            return Nums[MaxIdx1]* Nums[MaxIdx2];
        }
        static void Main(string[] args)
        {
            string N = Console.ReadLine();
            string[] x = Console.ReadLine().Split();
            List<long> nums = new List<long>();
            foreach(var item in x)
                nums.Add(int.Parse(item));
            Console.WriteLine(MaximumPairwiseProduct(nums.ToArray()));

            // stress test:
            // while(true){
            // Random rnd = new Random();
            // int x = rnd.Next() % 10 + 2;
            // List<long> nums = new List<long>();
            // for (int i=0; i<x; i++){
            //     nums.Add(rnd.Next()%9+1);
            // }
            // long x1 = MaximumPairwiseProduct(nums.ToArray());
            // long x2 = MaximumPairwiseProduct1(nums.ToArray());
            // if(x1 != x2){
            //     foreach (var n in nums)
            //         Console.Write("{0} ", n);
            //     Console.WriteLine("/n MPP={0}  MPP1={1}",x1, x2 );
            //     break;
            // }
            // else
            // {
            //     Console.WriteLine("OK: MPP={0}  MPP1={1}",x1, x2 );
            // }
            // }

        }
    }
}
