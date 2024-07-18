using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q2Pascal : Processor
    {
        public Q2Pascal(string testDataName) : base(testDataName)
        {
        }
        static long[,] MultiplyMatrix(long[,] _A, long[,] _B, int _n)
        {
            long[,] C = new long[_n, _n];
                for (int i = 0; i < _n; i++)
                    for (int j = 0; j < _n; j++)
                        for (int k = 0; k < _n; k++){
                            C[i,j] += (_A[i,k]*_B[k,j]) % (((long)Math.Pow(10, 9))+7);
                        }
                return C;
        }
        static long[,] PowMatrix(long[,] m, long n){
            if(n == 0){ return new long[2,2]{{1,0}, {0,1}}; }
            long[,] Mul = MultiplyMatrix(m,m,2);
            long[,] Pow = PowMatrix(Mul, n/2);
            if(n % 2 == 1){ Pow = MultiplyMatrix(m,Pow,2); }
            return Pow;
        }
        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long>)Solve);

        public static long Solve(long n)
        {
            long[,] x = {{1,1},{1,0}};
            long[,] result = PowMatrix(x, n);
            long remain = result[0,1] % (((long)Math.Pow(10, 9))+7);
            return remain;
        }
    }
}
