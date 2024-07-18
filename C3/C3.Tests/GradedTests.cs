using Microsoft.VisualStudio.TestTools.UnitTesting;
using C3;
using TestCommon;

namespace C3.Tests
{
    [DeploymentItem("TestData", "C3_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void Q1ArrayTest()
        {
            RunTest(new Q1Array("TD1"));
        }

        [TestMethod(), Timeout(2000)]
        public void Q2PascalTest()
        {
            RunTest(new Q2Pascal("TD2"));
        }

	// [TestMethod(), Timeout(5000)]
    //     public void Q3LshapeTest()
    //     {
    //         RunTest(new Q3Lshape("TD3"));
    //     }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C3", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
