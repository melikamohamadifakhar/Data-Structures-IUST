using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q5PortalsA : Processor
    {
        public Q5PortalsA(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ5PortalsA(inStr, Solve);

        public override Action<string, string> Verifier => E2Verifiers.VerifyQ5PortalsA;
    
        public bool Solve(int n, int m, int a_row, int a_col, int b_row, int b_col, char[,] board)
        {
            return false;
        }
    }
}
