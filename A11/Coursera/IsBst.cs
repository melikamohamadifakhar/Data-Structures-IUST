using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
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
        public static bool Solve(long[][] nodes)
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
        static void Main(string[] args){
            long num = int.Parse(Console.ReadLine());
            if(num == 0) {System.Console.WriteLine("CORRECT");
            return;}
            List<long[]> result = new List<long[]>();
            for(int i = 0; i < num; i++){
                result.Add(Console.ReadLine().Split().Select(x => Int64.Parse(x)).ToArray());
            }
            bool ans = Solve(result.ToArray());
            string answer;
            if(ans) { answer = "CORRECT"; } else { answer = "INCORRECT";}
            Console.WriteLine(answer);
        }
        // static void Main(string[] args){
        //     long bucketCnt = int.Parse(Console.ReadLine());
        //     long num = int.Parse(Console.ReadLine()); 
        //     string[] input = new string[num];
        //     for(int i = 0; i < num; i++)
        //     {
        //         input[i] = Console.ReadLine();
        //     }
        //     string[] output = Solve(bucketCnt,input);
        //     foreach(string i in output){
        //         Console.WriteLine(i);
        //     }
        // }
    }
    }

