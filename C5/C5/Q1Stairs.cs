using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q1Stairs : Processor
    {
        public Q1Stairs(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long m = first[1];
            long[] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, m, p).ToString();
        }

        public long Solve(long n, long m, long[] p)
        {
            double[] dp = new double[n+1];
            dp[0] = 1; dp[1] = 1; 
            for(int i=2; i<=n; i++){
                for(int j=0; j<m; j++){
                    if(i-p[j]>=1)
                    dp[i] += (dp[i- p[j]]) % (Math.Pow(10, 9)+7);
                }
            }
            return (long) (dp[n] % (Math.Pow((double)10,(double) 9)+7));
        }
    }
}
