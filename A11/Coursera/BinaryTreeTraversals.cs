using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
        public static long[] PostOrder(long[] roots, long[] lefts, long[] rights){
            List<long> result = new List<long>();
            long root = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                root = stack.Pop();
                result.Add(roots[root]);
                if(lefts[root] != -1)
                    stack.Push(lefts[root]);
                if(rights[root] != -1)
                    stack.Push(rights[root]);
            }
            result.Reverse();
            return result.ToArray();
        }
        public static long[] PreOrder(long[] roots, long[] lefts, long[] rights){
            List<long> result = new List<long>();
            long root = 0;
            Stack<long> stack = new Stack<long>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                root = stack.Pop();
                result.Add(roots[root]);
                if(rights[root] != -1)
                    stack.Push(rights[root]);
                if(lefts[root] != -1)
                    stack.Push(lefts[root]);
            }
            return result.ToArray();
        }
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
        public static long[][] Solve(long[][] nodes)
        {
            long[][] result = new long[3][];
            int l = nodes.Length;
            long[] roots = new long[l];
            long[] lefts = new long[l];
            long[] rights = new long[l];
            for(int i = 0; i < l; i++){
                roots[i] = nodes[i][0];
                lefts[i] = nodes[i][1];
                rights[i] = nodes[i][2];
            } 
            result[0] = (InOrder(roots, lefts, rights));
            result[1] = (PreOrder(roots, lefts, rights));
            result[2] = (PostOrder(roots, lefts, rights));
            return result;
        }
        static void Main(string[] args){
            long num = int.Parse(Console.ReadLine());
            List<long[]> result = new List<long[]>();
            for(int i = 0; i < num; i++){
                result.Add(Console.ReadLine().Split().Select(x => Int64.Parse(x)).ToArray());
            }
            long[][] ans = Solve(result.ToArray());
            foreach(var i in ans){
                foreach (var j in i){
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
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

