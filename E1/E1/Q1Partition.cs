using System;
using TestCommon;

namespace E1
{
    public class Q1Partition : Processor
    {
        public Q1Partition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ1Partition(inStr, Solve);

        public long Solve(long n, long x, long[] p)
        {
            Array.Sort(p);
            long min = p[0];
            long GroupNum=0; 
            for(int i=0; i<n; ){
                while((i<n) && (p[i] - min <= x)){
                    i++;
                }
                if(i<n){
                    min = p[i];
                    GroupNum+=1;}
                else
                    GroupNum+=1;}
            return GroupNum;
        }
    }
}
