using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LCS3
{
    class Program
    {
        public static long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long[,,] dp = new long[seq1.Length+1, seq2.Length+1, seq3.Length+1];
            for(int i = 0; i < seq1.Length+1; i++){
                dp[i, 0, 0] = 0;
            }
            for (int i=0; i <= seq2.Length; i++){
                dp[0, i, 0] = 0;
            }
            for (int i=0; i <= seq3.Length; i++){
                dp[0,0,i] = 0;
            }
            for (int i = 1; i<=seq1.Length; i++){
                for (int j=1; j<=seq2.Length; j++){
                    for(int k=1; k<=seq3.Length; k++){
                    if(seq1.ElementAt(i-1) == seq2.ElementAt(j-1) && seq1.ElementAt(i-1) == seq3.ElementAt(k-1))
                        dp[i,j,k] = dp[i-1,j-1,k-1]+1;
                    else
                        dp[i,j,k] = Math.Max(dp[i-1,j,k], Math.Max(dp[i,j-1,k], dp[i,j,k-1]));
                    
                }}
            }
            return dp[seq1.Length, seq2.Length, seq3.Length];
        }
        static void Main(string[] args)
        {
            long fsize = long.Parse(Console.ReadLine());
            long[] first = new long[fsize];
            string[] fstring = Console.ReadLine().Split();
            for(int i=0; i<fsize; i++){
                first[i] = long.Parse(fstring[i]);
            }
            long ssize = long.Parse(Console.ReadLine());
            long[] second = new long[ssize];
            string[] sstring = Console.ReadLine().Split();
            for(int i=0; i<ssize; i++){
                second[i] = long.Parse(sstring[i]);
            }
            long tsize = long.Parse(Console.ReadLine());
            long[] third = new long[tsize];
            string[] tstring = Console.ReadLine().Split();
            for(int i=0; i<tsize; i++){
                third[i] = long.Parse(tstring[i]);
            }

            Console.WriteLine(Solve(first, second, third));
        }
    }
}
