using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);

        public string maxSalary(long n, long[] strings){
            string[] str = sort(n, strings);
            string s = "";
            foreach(var st in str)
                s += st;
            return s;
        }
        public string[] sort(long n, long[] strs){
            for(int i = 0; i < n; i++){
                for(int j = i; j < n; j++){
                    if(compare(strs[i].ToString(), strs[j].ToString())){
                        long tmp = strs[j]; strs[j] = strs[i]; strs[i] = tmp;
                    }
                }
            }
            return strs.Select(x=>x.ToString()).ToArray();
        }
        public bool compare(string a, string b){
            int ab = int.Parse(a+b); int ba = int.Parse(b+a);
            if(ba>ab)
                return true;
            return false;
        }
        public virtual string Solve(long n, long[] numbers)
        {
            return maxSalary(n, numbers);
        }
    }
}

