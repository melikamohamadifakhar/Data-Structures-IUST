using System;
using System.Collections.Generic;

namespace Fibonacci_Number
{
    class Program
    {
        static long Fibonacci_Number(int a){
            List<long> Fibbonacci = new List<long>();
            Fibbonacci.Add(0);
            Fibbonacci.Add(1);
            for (int i=2; i <= a; i++)
                Fibbonacci.Add(Fibbonacci[i-2] + Fibbonacci[i-1]);
            return Fibbonacci[a];
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci_Number(a));
        }
    }
}
