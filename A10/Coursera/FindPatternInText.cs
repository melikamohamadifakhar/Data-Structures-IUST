using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
        public const int BigPrimeNumber = 1000000007;
        public static long[] Solve(string pattern, string text)
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
        static void Main(string[] args) {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            long[] ans = Solve(pattern, text);
            foreach(var item in ans) {
                Console.WriteLine($"{item} ");
            }
        }
        // static void Main(string[] args){
        //     long bucketCnt = int.Parse(Console.ReadLine());
        //     long num = int.Parse(Console.ReadLine()); 
        //     string[] input = new string[num];
        //     for(int i = 0; i < num; i++)
        //     {
        //         input[i] = Console.ReadLine();
        //     }
        //     string[] output = Solve(bucketCnt,input);
        //     foreach(string i in output){
        //         Console.WriteLine(i);
        //     }
        // }
    }
    }

