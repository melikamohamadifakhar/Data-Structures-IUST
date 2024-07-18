using System;

namespace MoneyChange
{
    class Program
    {
        static int MoneyChange(int value){
            int num=0;
            int TenNum= value/10; value-= 10*TenNum; num +=TenNum;
            int FiveNum= value/5; value-= 5*FiveNum; num +=FiveNum;
            num += value;
            return num;
        }
        static void Main(string[] args)
        {
            int Num = int.Parse(Console.ReadLine());
            Console.WriteLine(MoneyChange(Num));
        }
    }
}
