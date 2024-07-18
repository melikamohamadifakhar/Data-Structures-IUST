using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q2LCS : Processor
    {
        public Q2LCS(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);


        public static long Solve(string a, string b)
        {
            long aLen = a.Length;
            long bLen = b.Length;

            long[,] dpA = new long[aLen + 2, bLen + 2];
            long[,] dpB = new long[aLen + 2, bLen + 2];
            long cnt = 0;

            for (int i = 1; i <= aLen ; i++)
                for (int j = 1; j <= bLen ; j++)
                {
                    if (a[i - 1] == b[j - 1]){
                        dpA[i, j] = 1 + dpA[i - 1, j - 1]; continue;
                    }
                    dpA[i, j] = Math.Max(dpA[i - 1, j], dpA[i, j - 1]);
                
            }

            long Flcs = dpA[aLen, bLen];

            for (int i = (int)aLen; i > 0; i--)
                for (int j = (int)bLen; j >0; j--)
                {
                    if ((a[i-1] == b[j- 1])){
                        dpB[i, j] = 1 + dpB[i + 1, j + 1]; continue;
                    }
                    else
                    dpB[i, j] = Math.Max(dpB[i + 1, j], dpB[i, j+1]);
                }
            
            for (int i = 0; i <= aLen ; i++)
            {
                List<char> result = new List<char>();
                for (int j = 1; j < bLen + 1; j++)
                {
                    if (dpA[i, j - 1] + dpB[i+1, j + 1] == Flcs && !result.Contains(b[j-1]))
                    {
                        result.Add(b[j - 1]);
                        cnt++;
                    }
                }
            }
            return cnt;
        }
    }
}
