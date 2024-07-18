using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long [] a = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, x).ToString();
        }

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
    }
}
