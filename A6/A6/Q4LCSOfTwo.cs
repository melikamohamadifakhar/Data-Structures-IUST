using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] strj, long[] stri)
        {
            long[][] dp = new long[stri.Length+1][];
            for(int i = 0; i < dp.Length; i++){
                dp[i] = new long[strj.Length+1];
            }
            for (int i=0; i < dp.Length; i++){
                dp[i][0] = 0;
            }
            for (int i=0; i <= strj.Length; i++){
                dp[0][i] = 0;
            }
            for (int i = 1; i<dp.Length; i++){
                for (int j=1; j<=strj.Length; j++){
                    if(stri.ElementAt(i-1) == strj.ElementAt(j-1))
                        dp[i][j] = dp[i-1][j-1]+1;
                    else
                        dp[i][j] = Math.Max(dp[i-1][j-1], Math.Max(dp[i-1][j], dp[i][j-1]));
                    
                }
            }
            return dp[stri.Length][strj.Length];
        }
    }
}
