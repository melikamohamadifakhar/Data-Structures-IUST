using System;
using System.Linq;
namespace CarFueling
{
    class Program
    {
        static int MinRefills(int[] dists, int l, int num){
            int n=0; int current=0; int last=0;
            while (current<=num){
                last=current;
                while(current<=num && dists[current+1]-dists[last]<=l)
                    current +=1;
                if(current==last)
                    return -1;
                if(current<=num)
                    n+=1;
            } 
            return n;
        }
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] dists = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt32);
            int[] newdists= new int[n+2]; newdists[0]=0; newdists[n+1]= sum;
            for(int i=1; i<=n; i++)
                newdists[i] = dists[i-1];
            Console.WriteLine(MinRefills(newdists, l, n));
        }
    }
}
