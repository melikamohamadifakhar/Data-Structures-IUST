using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            if(souvenirsCount < 3){ return 0; }
            long sum=0;
            foreach (var item in souvenirs){
                sum += item;
            }
            if(sum % 3 != 0){ return 0; }
            long result =0;
            long[,] dp = new long[(sum/3)+1, souvenirsCount+1];
            for(int i=1; i<=(sum/3); i++){
                for(int j=1; j<=souvenirs.Length; j++){
                    dp[i,j] = dp[i, j-1];
                    if(souvenirs[j-1]<=i){
                        dp[i,j] = Math.Max(dp[i,j], dp[i-souvenirs[j-1],j-1] + souvenirs[j-1]);
                        if(dp[i,j] == (int) sum/3){
                            result++;
                        }
                    }
                }
            }
            if(result == 0){ return 0;}
            return 1;
        }
    }
}
