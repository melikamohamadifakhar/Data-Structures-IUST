using System;
using System.Collections.Generic;
namespace PerimitiveCalculator
{
    class Program
    {
        public static long[] Solve(long n){
        int[] nums = new int[n + 1];

        for (int i = 1; i < nums.Length; i++) {
            int divide3=i+1; int divide2 = i+1;
            if(i % 3 == 0)
                divide3 = nums[i/3];
            if(i % 2 == 0)
                divide2 = nums[i/2];
            nums[i] = Math.Min(nums[i-1], Math.Min(divide2, divide3)) + 1;
        }

        List<long> reversedResult = new List<long>();
        while (n>1) {
        bool x = false;
            reversedResult.Add(n);
            if (n % 3 == 0){
                if (nums[n / 3] + 1 == nums[n]){
                    x = true;
                    n /= 3;}
                }
            
            if (!x && n % 2 == 0){
                if (nums[n / 2] + 1 == nums[n]){
                    x = true;
                    n /= 2;}
                }
            
            if (!x && nums[n - 1] == nums[n] - 1)
                n-= 1;
        }
        long[] array = new long[reversedResult.Count];
        reversedResult.Add(1);
        array = reversedResult.ToArray();
        Array.Reverse(array);
        Console.WriteLine($"{array.Length-1}");
        return array;
        }
        static void Main(string[] args)
        {
            long n =  long.Parse(Console.ReadLine());
            foreach(var x in Solve(n))
                Console.Write($"{x} ");
        }
    }
}
