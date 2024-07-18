using System;

namespace second
{
    class Program
    {
        public static long Solve(long souvenirsCount, long[] souvenirs)
        {
            if(souvenirsCount < 3){ return 0; }
            long sum=0;
            foreach (var item in souvenirs){
                sum += item;
            }
            if(sum % 3 != 0){ return 0; }
            long result =0;
            long[,] dp = new long[(sum/3)+1, souvenirsCount+1];
            for(int i=1; i<=(sum/3); i++){
                for(int j=1; j<=souvenirs.Length; j++){
                    dp[i,j] = dp[i, j-1];
                    if(souvenirs[j-1]<=i){
                        dp[i,j] = Math.Max(dp[i,j], dp[i-souvenirs[j-1],j-1] + souvenirs[j-1]);
                        if(dp[i,j] == (int) sum/3){
                            result++;
                        }
                    }
                }
            }
            if(result == 0){ return 0;}
            return 1;
        }
        static void Main(string[] args)
        {
            long souvenirsCount = long.Parse(Console.ReadLine());
            string[] g = Console.ReadLine().Split();
            long[] goldbar = new long[g.Length];
            for(int i=0; i<g.Length; i++){
                goldbar[i] = long.Parse(g[i]);
            }
            Console.WriteLine(Solve(souvenirsCount, goldbar));
        }
    }
}
