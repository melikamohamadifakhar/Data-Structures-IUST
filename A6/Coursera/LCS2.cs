using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCS2
{
    class Program
    {
        public static long Solve(long[] strj, long[] stri)
        {
            long[][] dp = new long[stri.Length+1][];
            for(int i = 0; i < dp.Length; i++){
                dp[i] = new long[strj.Length+1];
            }
            for (int i=0; i < dp.Length; i++){
                dp[i][0] = 0;
            }
            for (int i=0; i <= strj.Length; i++){
                dp[0][i] = 0;
            }
            for (int i = 1; i<dp.Length; i++){
                for (int j=1; j<=strj.Length; j++){
                    if(stri.ElementAt(i-1) == strj.ElementAt(j-1))
                        dp[i][j] = dp[i-1][j-1]+1;
                    else
                        dp[i][j] = Math.Max(dp[i-1][j-1], Math.Max(dp[i-1][j], dp[i][j-1]));
                    
                }
            }
            return dp[stri.Length][strj.Length];
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

            Console.WriteLine(Solve(first, second));
        }
    }
}
