using System;

namespace MaximumGold
{
    class Program
    {
        public static long Solve(long W, long[] goldBars)
        {

            long[,] dp = new long[W+1, goldBars.Length+1];
            for(int i=1; i<=W; i++){
                for(int j=1; j<=goldBars.Length; j++){
                    dp[i,j] = dp[i, j-1];
                    if(goldBars[j-1]<=i){
                        dp[i,j] = Math.Max(dp[i,j], dp[i-goldBars[j-1],j-1] + goldBars[j-1]);
                    }
                }
            }
            return dp[W, goldBars.Length];
        }
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split();
            long w = long.Parse(str[0]);
            string[] g = Console.ReadLine().Split();
            long[] goldbar = new long[g.Length];
            for(int i=0; i<g.Length; i++){
                goldbar[i] = long.Parse(g[i]);
            }
            System.Console.WriteLine(Solve(w, goldbar));
        }
    }
}
