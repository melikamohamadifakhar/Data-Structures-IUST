using System;

namespace Greatest_Common_Divisor
{
    class Program
    {
        static long GCD(int a, int b){
            if(b==0)
                return a;
            return GCD(b, a%b);
        }
        static void Main(string[] args)
        {
            string[] inputs= Console.ReadLine().Split();
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            if(a>b)
                Console.WriteLine(GCD(a, b));
            else
                Console.WriteLine(GCD(b, a));
        }
    }
}
