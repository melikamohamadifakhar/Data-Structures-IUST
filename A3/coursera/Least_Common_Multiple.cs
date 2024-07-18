using System;

namespace Least_Common_Multiple
{
    class Program
    {
        static long GCD(int a, int b){
            if(b==0)
                return a;
            return GCD(b, a%b);
        }
        static Int64 LCM(int a, int b){
            long d = GCD(a, b);
            return (long) a*b/d;
        }
        static void Main(string[] args)
        {
            string[] inputs= Console.ReadLine().Split();
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            if(a>b)
                Console.WriteLine(LCM(a, b));
            else
                Console.WriteLine(LCM(b, a));
        }
    }
}
