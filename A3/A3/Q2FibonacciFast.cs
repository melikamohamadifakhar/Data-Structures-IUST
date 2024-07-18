using System;
using TestCommon;
using System.Collections.Generic;
namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long a)
        {
            List<long> Fibbonacci = new List<long>();
            Fibbonacci.Add(0);
            Fibbonacci.Add(1);
            for (int i=2; i <= a; i++)
                Fibbonacci.Add(Fibbonacci[i-2] + Fibbonacci[i-1]);
            return Fibbonacci[(int)a];
        }
    }
}
