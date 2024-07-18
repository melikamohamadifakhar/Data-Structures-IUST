using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);
        public static long bucketCnt = 0;
        List<string>[] hashTable;
        public string[] Solve(long bucketCount, string[] commands)
        {
            bucketCnt = bucketCount;
            hashTable = new List<string>[bucketCount];
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for(int i = str.Length - 1; i >= 0; i--){
                hash = ((hash*x) + str[i]) % p;
                // long si = str[i];
                // long xi = (long) Math.Pow(x, i);
                // hash += ((si*xi) + p)% p;
                // hash = (hash+p)  ;
            }
            return hash % bucketCnt;
        }

        public void Add(string str)
        {
            long hash = PolyHash(str, 0, str.Length);
            
            if(hashTable[hash] != null){
                if(hashTable[hash].Contains(str)){ return; }
            }
            else{
                hashTable[hash] = new List<string>();
            }
            hashTable[hash].Insert(0, str);
        }

        public string Find(string str)
        {
            long hash = PolyHash(str, 0, str.Length);
            if(hashTable[hash] != null){
                if(hashTable[hash].Contains(str)){
                    return "yes";
                }
            }
            return "no";
        }

        public void Delete(string str)
        {
            long hash = PolyHash(str, 0, str.Length);
            if(hashTable[hash] != null){
                    if(hashTable[hash].Contains(str)){
                        hashTable[hash].Remove(str);
                }
            }
        }

        public string Check(int i)
        {

                if(hashTable[i] == null || hashTable[i].Count == 0)
                    {return "-";}
                var list = hashTable[i];
                string str = "";
                for(int j = 0; j < list.Count; j++){
                    str += list[j] + " ";
                }
                return str.TrimEnd();

        }
    }
}
