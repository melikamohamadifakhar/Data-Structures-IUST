using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q1FlowerShop : Processor
    {
        public Q1FlowerShop(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long b = first[1];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, b, p).ToString();
        }
        static long Solve(long f, long p, long[] prices)
        {
            List<long> n = prices.OrderByDescending( x => x).ToList();
            int z=1; long sum=0;
            while (f>0){
                for(int i=0; i<p && f>0; i++){
                    sum += n[0]*z;
                    f--;
                    n.Remove(n[0]);
                }
                z+=1;
            }
            return sum;
        }
    }
}
