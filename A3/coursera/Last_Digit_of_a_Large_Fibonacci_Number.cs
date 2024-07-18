using System;
using System.Collections.Generic;

namespace Last_Digit_of_a_Large_Fibonacci_Number
{
    class Program
    {
        static int Fibonacci_Number(int a){
            List<int> Fibbonacci = new List<int>();
            Fibbonacci.Add(0);
            Fibbonacci.Add(1);
            for (int i=2; i <= a; i++){
                int fib_1 = Fibbonacci[i-2]%10;
                int fib_2 = Fibbonacci[i-1]%10;
                Fibbonacci.Add((fib_1+fib_2)%10);
            }
            return Fibbonacci[a];
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci_Number(a));
        }
    }
}
