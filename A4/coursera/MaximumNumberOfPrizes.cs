using System;
using System.Collections.Generic;

namespace MaximumNumberOfPrizes
{
    class Program
    {
        // static int Equation(int x){
        //     double delta = Math.Sqrt(1+(8*x));
        //     return (int)(-1+delta)/2;
        // }
        static List<int> MaximumNumberOfPrizes(int sum){
            List<int> prizes = new List<int>();
            if(sum==1){prizes.Add(1); 
            System.Console.WriteLine("1");
            return prizes;}
            for(int i=1; sum>0; i++){
                if(sum-i>=0)
                    prizes.Add(i);
                else if(i>0)
                    prizes[i-2] += sum;
                sum-=i;
            }
            return prizes.Count;
        }
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            List<int> prize = new List<int>();
            prize=MaximumNumberOfPrizes(int.Parse(input));
            foreach(var i in prize)
                System.Console.Write(i+" ");
        }
    }
}
