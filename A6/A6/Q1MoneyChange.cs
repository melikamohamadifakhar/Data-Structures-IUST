using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
//
namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] NumOfCoins = new long[n+1];
            for (int i = 1; i <= n; i++){
                NumOfCoins[i] = n;
                for (int j = 0; j < 3; j++){
                    long LastIdx = i - COINS[j];
                    if( (LastIdx >= 0) && ( NumOfCoins[LastIdx] < NumOfCoins[i]) ){
                        NumOfCoins[i] = NumOfCoins[LastIdx]+1;
                    }
                }
            }
            return NumOfCoins[n];
        }
    }
}
