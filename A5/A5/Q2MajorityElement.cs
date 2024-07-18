using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        static long getmajority(long[] nums, long l, long r){
            if(l == r) return nums[l];
            if(l - r == 1) return nums[l];
            long mid = (int) (l+r)/2;
            long leftElement = getmajority(nums, l, mid);
            long rightElement = getmajority(nums, mid+1, r);
            long lcount =0; long rcount =0;
            for(long i=l; i<=r; i++){
                if(leftElement == nums[i])
                    lcount++;
                if(rightElement == nums[i])
                    rcount++;
            }
            if(lcount > rcount) return leftElement;
            return rightElement;
        }
        public virtual long Solve(long n, long[] a)
        {
            long MajElement = getmajority(a, 0, n-1);
            int c=0;
            for(int i=0; i<a.Length; i++)
                if(a[i] == MajElement) c++;
            if(c > n/2)
                return 1;
            return 0;
        }
    }
}
