using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class obj
    {
        public List<long> array = new List<long>();
        public List<List<long>> result = new List<List<long>>();
    }
    class Program
    {
        public static List<long> swap(List<long> array, long i, long j){
            long tmp = array[(int)i];
            array[(int)i] = array[(int)j];
            array[(int)j] = tmp;
            return array;
        }
        public static obj SiftDown(obj o, long i){
            long minIdx = i ; long len = o.array.Count;
            long left = 2*i + 1; long right = 2*i + 2;
            if(right < len && o.array[(int)right]<o.array[(int)minIdx]){
                minIdx = right;
            }
            if(left < len && o.array[(int)left]<o.array[(int)minIdx]){
                minIdx = left;
            }
            if(i != minIdx){
                swap(o.array, i, minIdx);
                List<long> add = new List<long>(); add.Add(i); add.Add(minIdx);
                o.result.Add(add);
                SiftDown(o, minIdx);
            }
            return o;
        }
        public static List<List<long>> Solve(List<long> array)
        {
            int len = array.Count/2-1;
            obj o = new obj();
            o.array = array;
            for (int i = len ; i >= 0 ; i--)
            {
                var t = SiftDown(o, i);
                o.result = t.result;
                o.array = t.array;
            }
            return o.result;
        }
        static void Main(string[] args)
        {
            long num = Int64.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split();
            List<long> result = new List<long>();
            for(int i = 0; i < num; i++){
                result.Add(Int64.Parse(s[i]));
            }
            List<List<long>> ans = Solve(result);
            Console.WriteLine(ans.Count);
            foreach(var i in ans){
                Console.WriteLine($"{i[0]} {i[1]}");
            }

        }
    }
}
