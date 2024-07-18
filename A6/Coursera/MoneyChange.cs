using System;

namespace MoneyChange
{
    class Program
    {
    private static readonly int[] COINS = new int[] {1, 3, 4};
        public static long Solve(long n)
        {
            long[] NumOfCoins = new long[n+1];
            for (int i = 1; i <= n; i++){
                NumOfCoins[i] = n;
                for (int j = 0; j < 3; j++){
                    long LastIdx = i - COINS[j];
                    if( (LastIdx >= 0) && ( NumOfCoins[LastIdx] < NumOfCoins[i]) ){
                        NumOfCoins[i] = NumOfCoins[LastIdx]+1;
                    }
                }
            }
            return NumOfCoins[n];
        }
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine(Solve(money));
        }
    }
}
