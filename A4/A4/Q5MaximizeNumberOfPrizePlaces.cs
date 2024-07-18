using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] MaximumNumberOfPrizes(long sum){
            List<long> prizes = new List<long>();
            if(sum==1){prizes.Add(1); 
            return prizes.ToArray<long>();}
            for(int i=1; sum>0; i++){
                if(sum-i>=0)
                    prizes.Add(i);
                else if(i>0)
                    prizes[i-2] += sum;
                sum-=i;
            }
            return prizes.ToArray<long>();
        }
        public virtual long[] Solve(long n)
        {
            return MaximumNumberOfPrizes(n);
        }
    }
}

