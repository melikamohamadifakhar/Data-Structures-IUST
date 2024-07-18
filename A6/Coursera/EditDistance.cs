using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EditDistance
{

    class Program
    {
        public static long Solve(string strj, string stri)
        {
            long[][] dp = new long[stri.Length+1][];
            for(int i = 0; i < dp.Length; i++){
                dp[i] = new long[strj.Length+1];
            }
            for (int i=0; i < dp.Length; i++){
                dp[i][0] = i;
            }
            for (int i=0; i <= strj.Length; i++){
                dp[0][i] = i;
            }
            for (int i = 1; i<dp.Length; i++){
                for (int j=1; j<=strj.Length; j++){
                    if(stri.ElementAt(i-1) == strj.ElementAt(j-1))
                        dp[i][j] = dp[i-1][j-1];
                    else
                        dp[i][j] = Math.Min(dp[i-1][j-1], Math.Min( dp[i-1][j], dp[i][j-1])) + 1;
                }
            }
            return dp[stri.Length][strj.Length];
        }
        static void Main(string[] args)
        {
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            Console.WriteLine(Solve(string1, string2));
        }
    }
}
