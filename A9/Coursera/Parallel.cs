using System;
using System.Collections.Generic;

namespace newfol
{
    class Program
    {
        public static int Left(int i){ return 2*i + 1; }
        public static int Right(int i){ return 2*i + 2; }
        public static void SiftDown(List<long[]> Tree)
        {
            int i=0;
            while(i <= (int)(Tree.Count/2 - 1))
            {
                int min = i;
                if(Tree.Count >= Left(i) + 1)
                {
                    if(Tree[min][1] > Tree[Left(i)][1])
                        min = Left(i);
                    else if(Tree[min][1] == Tree[Left(i)][1])
                    {
                        if(Tree[min][0] > Tree[Left(i)][0])    
                            min = Left(i);
                    }
                }
                if(Tree.Count >= Right(i) + 1)
                {
                    if(Tree[min][1] > Tree[Right(i)][1])
                        min = Right(i);
                    else if(Tree[min][1] == Tree[Right(i)][1])
                    {
                        if(Tree[min][0] > Tree[Right(i)][0])    
                            min = Right(i);
                    }
                }
                if (min != i)
                {
                    swap(Tree[i], Tree[min]);
                    i = min;
                }
            }
        }
        static void swap(long[] x, long[] y){
            long[] tmp = x;
            x = y;
            y = tmp;
        }
        static void Main(string[] args)
        {
            var In = Console.ReadLine().Split();
            long Process_cnt = long.Parse(In[0]);
            long Jobs_cnt = long.Parse(In[1]);
            long[] Jobs = new long[Jobs_cnt];
            string[] In2 = Console.ReadLine().Split();
            for(int i=0; i<Jobs_cnt; i++)
            {
                Jobs[i] = long.Parse(In2[i]);
            }
            List<Tuple<long,long>> Ans = new List<Tuple<long, long>>();
            List<long[]> Tree = new List<long[]>();
            for(int i = 0; i < Process_cnt; i++)
                Tree.Add(new long[]{i,0});
            for(int i = 0; i < Jobs_cnt; i++)
            {
                Ans.Add(new Tuple<long, long>(Tree[0][0] , Tree[0][1]));
                Tree[0][1] += Jobs[i];
                SiftDown(Tree);
            }
            for(int i=0; i<Ans.Count; i++)
                Console.Write(Ans[i].Item1 + " " + Ans[i].Item2 + "\n");
        }
    }
}
