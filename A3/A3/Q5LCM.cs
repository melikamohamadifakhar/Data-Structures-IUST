using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);
        public long GCD(long a, long b)
        {
            if(a<b){long c=a; a=b; b=c;} 
            if(b==0)
                return a;
            return GCD(b, a%b);
        }
        public long Solve(long a, long b)
        {
            long d = GCD(a, b);
            return (long) a*b/d;
        }

    }
}
