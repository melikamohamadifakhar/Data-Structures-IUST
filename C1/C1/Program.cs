using System;
using System.Collections.Generic;
using System.Linq;

namespace C1
{
    class Program
    {
        static long Solve(long n, long[] a, long x){
            List<long> poor = new List<long>();
            int num=0; long sum=0; int equal = 0; int reach=0;
            foreach (var item in a){
                if(item==x) equal++; 
                if(item<x) poor.Add(item);
                if(item>x) {sum+=(item-x); reach++;} 
            } poor.OrderByDescending(p => p);
            for(int i=0; i<poor.Count; i++){
                while(poor[i]<x && sum>0){
                    poor[i]++; sum--;
                    if(poor[i]==x){num++; break;} 
                }
            }
            return num+reach+equal;
        }
        static void Main(string[] args)
        {
            long[] x = {9, 9, 8, 8, 7, 6, 5, 5, 3, 3};
            Console.WriteLine(Solve(10, x, 5));
        }
    }
}
