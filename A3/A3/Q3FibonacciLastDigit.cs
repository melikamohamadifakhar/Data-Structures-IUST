using System;
using TestCommon;
using System.Collections.Generic;
namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long a)
        {
            int current = 0; int next=1; int sum=1;
            for (int i=2; i <= a; i++){
                sum=(current + next)%10; 
                current = next%10; next = sum; 
            }
            return sum;
        }
    }
}
