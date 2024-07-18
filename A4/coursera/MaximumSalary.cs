using System;

namespace MaximumSalary
{
    class Program
    {
        static string maxSalary(string[] strings){
            string[] str = sort(strings);
            string s = "";
            foreach(var st in str)
                s += st;
            return s;
        }
        static string[] sort(string[] strs){
            for(int i = 0; i < strs.Length; i++){
                for(int j = i; j < strs.Length; j++){
                    if(compare(strs[i], strs[j])){
                        string tmp = strs[j]; strs[j] = strs[i]; strs[i] = tmp;
                    }
                }
            }
            return strs;
        }
        static bool compare(string a, string b){
            int ab = int.Parse(a+b); int ba = int.Parse(b+a);
            if(ba>ab)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] str = new string[num];
            str = Console.ReadLine().Split();
            System.Console.WriteLine(maxSalary(str));
        }
    }
}
