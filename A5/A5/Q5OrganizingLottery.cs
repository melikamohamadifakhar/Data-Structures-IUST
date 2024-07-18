using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] OrganizingLottery(long[] points, long[] starts, long[] ends){
            long[] result = new long[points.Length];
            long pLen = points.Length;
            for(int i = 0; i < pLen; i++){
                long keyInStart = startBinarySearch(starts, points[i], 0, starts.Length-1);
                long keyInEnd = endBinarySearch(ends, points[i], 0, ends.Length-1);
                long diff = keyInStart-keyInEnd;
                if(diff >= 0 ) result[i] = diff;
                else result[i] = 0;
            }
            return result;
        }
        public virtual long[] Solve(long[] points, long[] starts, long[] ends)
        {
            Array.Sort(starts);
            Array.Sort(ends);
            return OrganizingLottery(points, starts, ends);
        }
        public virtual long startBinarySearch(long[] Array, long key, long low, long high)
        {
            if (high<0)
                return -1;
            if (low>high)
                return high;

            long mid = (int)((low+high)/2);

            if (Array[mid] < key)
                return startBinarySearch(Array, key, mid+1, high);

            
            else if(Array[mid] == key)
            {
                while (mid < Array.Length-1)
                {
                    if (Array[mid] == Array[mid+1])
                        mid+=1;
                    else
                        break;
                }
                return mid;
            }

            else
            {
                if (mid==0)
                    return -1;
                else if (Array[mid-1] < key)
                    return mid-1;
                else
                    return startBinarySearch(Array, key, low, mid-1);
            }


        }





        public virtual long endBinarySearch(long[] Array, long key, long low, long high)
        {
            if (high<0)
                return -1;
            if (low>high)
                return high;
            long mid = (int)((low+high)/2);
            if (Array[mid]<key)
                return endBinarySearch(Array, key, mid+1, high);
            else if (Array[mid]>key)
            {
                if (mid==0)
                    return -1;
                else if (Array[mid-1]<key)
                    return mid-1;
                else
                    return endBinarySearch(Array, key, low, mid-1);
            }
            else
            {
                while (mid-1>=0)
                {
                    if (Array[mid]==Array[mid-1])
                        mid-=1;
                    else
                        break;
                }
                return mid-1;
            }
        }
    }
}
