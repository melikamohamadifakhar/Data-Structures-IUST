using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q4ChainingProfiler : Processor
    {
        public Q4ChainingProfiler(string testDataName) : base(testDataName)
        {
        }

        /// <summary>
        /// FNV-1a - (Fowler/Noll/Vo) is a fast, consistent, non-cryptographic hash algorithm with good dispersion. (see http://isthe.com/chongo/tech/comp/fnv/#FNV-1a)
        /// </summary>
        private static int GetFNV1aHashCode(string str, int bucketCount)
        {
            if (str == null)
                return 0;
            var length = str.Length;
            int hash = length;
            for (int i = 0; i != length; ++i)
                hash = (hash ^ str[i]) * 16777619;
            return (hash % bucketCount + bucketCount) % bucketCount;
        }

        public override string Process(string inStr) => E2Processors.ProcessQ4ChainingProfiler(inStr, Solve);

        // Returns:
        //      A Tuple:
        //          Item1 = Adjusted sample variance of the chain lengths
        //          Item2 = Hash table, a list of length bucketCount
        public Tuple<double, List<LinkedList<string>>> Solve(int n, int bucketCount, string[] s)
        {
            List<LinkedList<string>> hashtable = new List<LinkedList<string>>();
            for(int i = 0; i<n; i++){
                int hashed = GetFNV1aHashCode(s[i], bucketCount);
                while(hashed >= hashtable.Count){
                    hashtable.Add(new LinkedList<string>());
                }
                    hashtable[hashed].AddLast(s[i]);
            }
            int cnt = hashtable.Count;
            long sum = 0;
            for(int i = 0; i<cnt; i++){
                sum += hashtable[i].Size();
            }   double avg = (double) sum/cnt;
            double sum2 = 0;
            for(int i = 0; i<cnt; i++){
                sum2 += Math.Pow((hashtable[i].Size() - avg), 2);
            }
            return Tuple.Create((double)sum2/(cnt-1), hashtable);
        }
    }
}
