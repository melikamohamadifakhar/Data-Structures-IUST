using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q2Froggie : Processor
    {
        public Q2Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[][] dp = new long[2][];
            dp[0] = new long[n];
            dp[1] = new long[n];
            dp[0][0] = numbers[0][0];
            dp[1][0] = numbers[1][0];
            for (int i = 1; i < n; i++)
            {
                long x1 = dp[0][i-1] + numbers[0][i];
                long x2 = dp[1][i-1] + numbers[0][i]-p;
                long x3 = dp[1][i-1] + numbers[1][i];
                long x4 = dp[0][i-1] + numbers[1][i]-p;
                dp[0][i] = Math.Max(x1,x2);
                dp[1][i] = Math.Max(x3,x4);
            }
            return Math.Max(dp[0][n-1],dp[1][n-1]);
        }

    }
}
