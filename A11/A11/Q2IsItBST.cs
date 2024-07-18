using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        public static long[] InOrder(long[] roots, long[] lefts, long[] rights){
            List<long> result = new List<long>();
            long root = 0;
            Stack<long> stack = new Stack<long>();
            while(root != -1 || (stack.Count > 0))
            {
                if(root >= 0){
                    if(root<roots.Length)
                        {stack.Push(root);
                        root = lefts[root];
                        continue;}
                }
                long node = stack.Pop();
                result.Add(roots[node]);
                root = rights[node];
                
            }
            return result.ToArray();
        }
        public bool Solve(long[][] nodes)
        {
            int l = nodes.Length;
            long[] roots = new long[l];
            long[] lefts = new long[l];
            long[] rights = new long[l];
            for(int i = 0; i < l; i++){
                roots[i] = nodes[i][0];
                lefts[i] = nodes[i][1];
                rights[i] = nodes[i][2];
            } 
            long[] result = InOrder(roots, lefts, rights);
            for(int i = 1; i < l; i++){
                if(result[i-1] > result[i])
                    return false;
            }
            return true;
        }
    }
}
