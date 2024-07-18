using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q1Toys : Processor
    {
        public Q1Toys(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long [] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, arr).ToString();
        }
        public static long Solve(long a, long[] arr)
        {
            Array.Reverse(arr);
            List<long> dp = new List<long>();
            dp.Add(arr[0]);
            dp.Add(arr[0] + arr[1]);
            dp.Add(arr[0]+arr[1] + arr[2]);
            int index = 3;
            long sum = 0;
            for (long i = 0; i < 3; i++)
            {
                sum += arr[i];
            }
            while (index < a)
            {
                long x1 = arr[index] + sum - dp[index-1];
                long x2 = arr[index] + sum - dp[index-2];
                long x3 = arr[index] + sum - dp[index-3];
                long max = Math.Max(Math.Max(x1, x2), x3);
                dp.Add(max);
                sum += arr[index];
                index++;
            }
            int l = dp.Count;
            return dp[l-1];
        }
    }
}
