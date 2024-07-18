using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumValueOfTheLoot
{
    
    class Program
    {
        static double[,] Sort2d(double[,] arr){
        for (int i = 0; i < arr.GetLength(0); i++)
            for(int j=i; j<arr.GetLength(0); j++){
                double first= arr[i,0]/arr[i,1];
                double second= arr[j,0]/arr[j,1];
                if(second > first){
                    var tmp = arr[i,0]; arr[i,0] = arr[j,0]; arr[j,0] = tmp;
                    var tmp1 = arr[i,1]; arr[i,1] = arr[j,1]; arr[j,1] = tmp1;
                }
            }
        return arr;
}

        static double MaximumValue(int Num, double W, double[,] array){
            double[,] ordered = Sort2d(array);
            double max=0;
            for(int i=0; i<Num; i++){
                if(W>0){
                    double value = (ordered[i,0]/ordered[i,1]);
                    max += Math.Min(W, ordered[i,1]) * value;
                    W -= ordered[i,1];
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            int num; double weight;
            string[] x =Console.ReadLine().Split();
            num = int.Parse(x[0]); weight = int.Parse(x[1]);
            double[,] arr = new double[num,2];
            for(int i=0; i<num; i++){
                string[] inputs =Console.ReadLine().Split();
                arr[i,0] = double.Parse(inputs[0]);
                arr[i,1] = double.Parse(inputs[1]);
            }
            System.Console.WriteLine(MaximumValue(num, weight, arr));
        }
    }
}
