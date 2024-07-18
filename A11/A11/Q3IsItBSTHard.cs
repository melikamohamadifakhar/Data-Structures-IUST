using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        public static bool InOrder(long[] roots, long[] lefts, long[] rights){
            long root = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                root = stack.Pop();
                if(root != -1){
                    if(rights[root] != -1){
                        if(roots[rights[root]] < roots[root] )
                            return false;
                    }
                    if(lefts[root] != -1){
                        if(roots[lefts[root]] >= roots[root] )
                            return false;
                    }
                    stack.Push(rights[root]);
                    stack.Push(lefts[root]);
                }
            }
            return true;
        }
        public static bool IsBST(long[][] nodes, long[] root, long max, long min){
            if(root == null) { return true; }
            if(root[0] < min || root[0] >= max)
                { return false; }
            long[] rightnode, leftnode;
            if(root[2] == -1) { rightnode = null; }
            else { rightnode = nodes[root[2]]; }
            if(root[1] == -1) { leftnode = null; }
            else { leftnode = nodes[root[1]]; }
            if(root[1] != -1 && IsBST(nodes, leftnode, root[0], min)==false)
            { return false;}
            if(root[2] != -1 && IsBST(nodes, rightnode, max, root[0])==false)
            { return false;}
            return true;
        }
        public bool Solve(long[][] nodes)
        {
            long[] root = nodes[0];
            bool right = IsBST(nodes, root, long.MaxValue, long.MinValue);
            bool left = IsBST(nodes, root, long.MaxValue, long.MinValue) ;
            if(root[1] != -1 && left==false)
            { return false;}
            if(root[2] != -1 && right==false)
            { return false;}
            return true;
        }
    }
}
