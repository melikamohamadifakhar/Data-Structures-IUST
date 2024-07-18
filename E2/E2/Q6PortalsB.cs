using E2.Helper;
using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q6PortalsB : Processor
    {
        public Q6PortalsB(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ6PortalsB(inStr, Solve);

        public int Solve(int n, int m, int a_row, int a_col, int b_row, int b_col, char[,] board, List<Portal> portals)
        {
            throw new NotImplementedException();
        }
    }
}
