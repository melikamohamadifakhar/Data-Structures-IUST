using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            
            Stack stack = new Stack();
            char[] strs = str.ToCharArray();
            char[] open = {'(', '[', '{'};
            char[] close = {')', ']', '}'};
            int idx = 0; int wrongidx=0;
            while(idx < strs.Length){
                char current = strs[idx];
                if(!open.Contains(current) && !close.Contains(current))
                    {idx++; continue;}
                if(open.Contains(current)){
                    wrongidx = idx;
                    stack.Push(current);
                    idx++;
                }
                else if(close.Contains(current)){
                    if(stack.Count == 0){return idx+1;}
                    object last = stack.Pop();
                    if(current == ')' && last.ToString() == "("){ idx++; wrongidx--; continue; }
                    if(current == ']' && last.ToString() == "["){ idx++; wrongidx--;continue; }
                    if(current == '}' && last.ToString() == "{"){ idx++; wrongidx--;continue; }
                    return idx+1 ;
                }
            }
                if(stack.Count == 0){wrongidx = -2;}
                return wrongidx+1;
        }
    }
}
