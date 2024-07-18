using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            long num=0;
            long TenNum= money/10; money-= 10*TenNum; num +=TenNum;
            long FiveNum= money/5; money-= 5*FiveNum; num +=FiveNum;
            num += money;
            return num;
        }
    }
}
