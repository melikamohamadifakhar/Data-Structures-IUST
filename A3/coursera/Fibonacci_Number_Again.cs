using System;
using System.Collections.Generic;

namespace Fibonacci_Number_Again
{
    class Program
    {
        static long Fibonacci_Number(long a, long b){
            List<long> Fibbonacci = new List<long>();
            Fibbonacci.Add(0);
            Fibbonacci.Add(1);
            for (int i=2; i <= a; i++){
                long fib_1 = Fibbonacci[i-2]%b;
                long fib_2 = Fibbonacci[i-1]%b;
                Fibbonacci.Add((fib_1+fib_2)%b);
            }
            return Fibbonacci[(int)a];
        }
        static long Fibonacci(long a, long b){
            if(a<=1)
                return a;
            long periodLen=1;
            long previous=0; long current=1;
            while(true){
                long newnum = (current+previous)%b;
                previous = current;
                current = newnum;
                if ((previous%b ==0) && (current%b ==1))
                    break;
                periodLen+=1;
            }
            long fib = Fibonacci_Number((a%periodLen), b);
            return fib;
        }
        static void Main(string[] args)
        {
            string[] inputs= Console.ReadLine().Split();
            long a = Int64.Parse(inputs[0]);
            long b = Int64.Parse(inputs[1]);
            Console.WriteLine(Fibonacci(a, b));
        }
    }
}
