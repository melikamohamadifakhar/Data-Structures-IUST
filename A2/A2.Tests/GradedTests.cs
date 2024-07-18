using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;
using System.Diagnostics;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest(){
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while(sw.ElapsedMilliseconds <= 500){
            Random rnd = new Random();
            int x = rnd.Next() % 10 + 2;
            List<long> nums = new List<long>();

            for (int i = 0; i < x; i++){
                nums.Add(rnd.Next() % 9 + 1);
            }
            
            var q1 = new Q1NaiveMaxPairWise("T1");
            long naive = q1.Solve(nums.ToArray());
            var q2 = new Q2FastMaxPairWise("TD2");
            long fast = q2.Solve(nums.ToArray());

            if(naive != fast){
                foreach (var n in nums)
                    Console.Write("{0} ", n);
                Console.WriteLine("/n NaiveFuncAns={0}  FastFuncAns={1}", naive, fast );
                break;
            }
            }
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}