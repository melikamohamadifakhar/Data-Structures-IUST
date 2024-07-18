using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q1Reverse : Processor
    {
        public Q1Reverse(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ1Reverse(inStr, Solve);

        public LinkedList<long> Solve(long n, LinkedList<long> list)
        {
            // LinkedList<long> ans = new LinkedList<long>();
            Stack<Node<long>> stack = new Stack<Node<long>>();
            Node<long> ptr = list.Head;
            int cnt = 1;
            while(ptr != list.Tail){
                stack.Push(ptr); cnt++;
                ptr = ptr.Next;
            }
            // stack.Push(list.Tail);
            list.Head = ptr;
            while(cnt > 1){
                ptr.Next = stack.Peek();
                ptr = ptr.Next;
                stack.Pop();
                cnt--;
            }
            ptr.Next = null;
            list.Tail = ptr;
            return list;
        }
    }
}
