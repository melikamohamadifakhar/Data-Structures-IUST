using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q2Truck : Processor
    {
        public Q2Truck(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ2Truck(inStr, Solve);
        

        public long Solve(long n ,long[] petr ,long[] dist)
        {
            long min = long.MaxValue; long idx=0; long gas_i = petr[0];
            if(dist.Sum() > petr.Sum()){
                return -1;
            }
            for(int i=1; i<n; i++){
                gas_i -= dist[i-1];
                if(gas_i< min){
                    idx = i;
                    min = gas_i;
                }
                gas_i += petr[i];
            }
            long last = gas_i - dist[n-1] ;
            if(last < min){
                return 0;
            }
            else{
                if(min>0)
                {
                    return 0;
                }
            }
            return idx;
        }
    }
}
