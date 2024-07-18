using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);
        public const int BigPrimeNumber = 1000000007;
        public long[] Solve(string pattern, string text)
        {
            Random rand = new Random();
            long x = rand.Next(1, BigPrimeNumber-1);
            List<long> result = new List<long>();
            long phash = PolyHash(pattern, x);
            int pcount = pattern.Length;
            int tcount = text.Length;
            long[] H = PreComputeHashes(text, pcount, BigPrimeNumber, x);
            for(int i = 0; i <= tcount - pcount; i++){
                if(phash != H[i]) continue;
                if(text.Substring(i, pcount) == pattern) { result.Add(i); }
            }
            return result.ToArray();
        }
        public static long PolyHash(
            string str, long x,
            long p = BigPrimeNumber)
        {
            long hash = 0;
            for(int i = str.Length-1; i > -1; i--){
                hash = ((hash*x + str[i]));
                hash = hash % p ;
            }
            return hash;
        }
        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            int tLen = T.Length;
            long[] H = new long[tLen - P + 1];
            string s = T.Substring(tLen-P, P);
            H[tLen - P] = PolyHash(s, x);
            long y = 1;
            for (int i = 1; i <= P; i++){
                y = (y*x) % p;
            }
            for(int i = tLen-P-1; i >= 0; i--){
                H[i] = (((x*H[i+1] + T[i] - y*T[i + P]) % p) + p) % p;
            }
            return H;
        }
    }
}
