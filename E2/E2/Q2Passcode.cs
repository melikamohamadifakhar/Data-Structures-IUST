using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q2Passcode : Processor
    {
        public Q2Passcode(string testDataName) : base(testDataName)
        {
        }
        public override Action<string, string> Verifier => E2Verifiers.VerifyQ2Passcode;

        public override string Process(string inStr) => E2Processors.ProcessQ2Passcode(inStr, Solve);

        public Tuple<int,int> Solve(long n, long x, long[] a)
        {
            IDictionary<double, int> dict = new Dictionary<double, int>();
            for(int i = 0; i<n; i++){
                if(!dict.ContainsKey(a[i]))
                    dict.Add(a[i], i+1);
                else if(x ==  a[i]*a[i]){
                    return Tuple.Create(dict[a[i]], i+1);
                }
            }
            foreach(var item in dict){
                double t = x/item.Key;
                if(dict.ContainsKey(t)){
                    return Tuple.Create(dict[item.Key], dict[x/item.Key]);
                }
            }
            // if(dict.ContainsKey(x)) { return dict[x]; }
            return null;
        }
    }
}
