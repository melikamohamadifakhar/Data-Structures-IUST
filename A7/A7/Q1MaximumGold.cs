using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {

            long[,] dp = new long[W+1, goldBars.Length+1];
            for(int i=1; i<=W; i++){
                for(int j=1; j<=goldBars.Length; j++){
                    dp[i,j] = dp[i, j-1];
                    if(goldBars[j-1]<=i){
                        dp[i,j] = Math.Max(dp[i,j], dp[i-goldBars[j-1],j-1] + goldBars[j-1]);
                    }
                }
            }
            return dp[W, goldBars.Length];
        }
    }
}
