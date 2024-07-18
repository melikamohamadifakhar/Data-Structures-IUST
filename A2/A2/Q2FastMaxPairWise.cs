using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s))
                .ToArray()).ToString();

        public virtual long Solve(long[] Nums)
        {
            int MaxIdx1 = -1;
            for (int i = 0; i < Nums.Length; i++){
                if(MaxIdx1==-1 || Nums[i]>Nums[MaxIdx1]){
                    MaxIdx1=i;
                }
            }
            int MaxIdx2 = -1;
            for (int j = 0; j < Nums.Length; j++){
                if(j != MaxIdx1 && (MaxIdx2 == -1 || Nums[j]> Nums[MaxIdx2])){
                    MaxIdx2=j;
                }
            }
            return Nums[MaxIdx1]* Nums[MaxIdx2];
        }
    }
}
