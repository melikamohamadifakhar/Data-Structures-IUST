using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
        public static long Solve(string str)
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
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            long res = Solve(s);
            if(res == -1)
                Console.WriteLine("Success");
            else
                Console.WriteLine(res);
        }
    }
}
