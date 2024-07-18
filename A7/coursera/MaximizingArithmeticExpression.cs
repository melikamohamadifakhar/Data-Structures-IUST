using System;
using System.Collections.Generic;
namespace third
{
    class Program
    {
        public static long Solve(string expression)
        {
            List<long> numbers = new List<long>();
            List<char> ops = new List<char>();
            for(int i=0; i < expression.Length; i++){
                if( i % 2 ==0)
                    numbers.Add(Int64.Parse(expression[i].ToString()));
                else 
                    ops.Add(expression[i]);
            }
            return paranthesis(numbers.ToArray(), ops);

        }
        public static long paranthesis(long[] nums, List<char> ops){
            int l = nums.Length;
            long[,] MinArr = new long[l+1,l+1];
            long[,] MaxArr = new long[l+1,l+1];
            for(int i=1; i<=l; i++){
                MinArr[i,i] = nums[i-1];
                MaxArr[i,i] = nums[i-1];
            }
            for(int s =1; s<l; s++){
                for(int i=1; i<=l-s; i++){
                    int j = i+s;
                    long[] MinMax = MinAndMax(MinArr, MaxArr, i, j, ops);
                    MinArr[i, j] = MinMax[0];
                    MaxArr[i, j] = MinMax[1];
                }
            }
            return MaxArr[1,l];
        }
        public static long[] MinAndMax(long[,] MinArr, long[,] MaxArr, int i, int j, List<char> ops){
            long min = Int64.MaxValue; long max = Int64.MinValue;
            for(int k = i; k<j; k++){
                List<long> values = new List<long>();
                    values.Add(eval(MaxArr[i,k], MaxArr[k+1, j], ops[k-1]));
                    values.Add(eval(MaxArr[i,k], MinArr[k+1, j], ops[k-1]));
                    values.Add(eval(MinArr[i,k], MinArr[k+1, j], ops[k-1]));
                    values.Add(eval(MinArr[i,k], MaxArr[k+1, j], ops[k-1]));
                
                values.Sort();
                min = Math.Min(values[0], min);
                max = Math.Max(values[3], max);
            }
            return new long[]{min, max};
        }
        public static long eval(long a, long b, char op){
            if(op == '+')
                return a+b;
            else if(op == '*')
                return a*b;
            else
                return a-b;
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(Solve(s));
        }
    }
}
