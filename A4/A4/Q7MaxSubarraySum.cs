using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long maxSub(long left, long right, long[] array){
            if(left == right)
                return array[left];

            long[] result = new long[3];

            long mid = (left+right)/2;
            result[0] = maxSub(left, mid, array);
            result[1] = maxSub(mid+1, right, array);

            long max1= array[mid]; long sum1=0;
            for(long i = mid; i>=left; i--){
                sum1 += array[i];
                max1 = Math.Max(max1, sum1);
            }

            long max2= array[mid+1]; long sum2=0;
            for(long j=mid+1; j<=right; j++){
                sum2 += array[j];
                max2 = Math.Max(max2, sum2);
            } 

            result[2] = max1+max2;
            return result.Max();
        }
        public virtual long Solve(long n, long[] numbers)
        {
            return maxSub(0, n-1, numbers);
        }
    }
}
