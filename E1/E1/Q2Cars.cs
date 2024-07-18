using System;
using TestCommon;

namespace E1
{
    public class Q2Cars : Processor
    {
        public Q2Cars(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ2Cars(inStr, Solve);
        public double GetDistance(long aX, long aY, long bX, long bY){
            double xdist = Math.Pow((aX-bX), 2);
            double ydist = Math.Pow((aY-bY), 2);
            return Math.Sqrt(xdist + ydist);
        }
        public double DistTimePercent(long aX, long aY, long bX, long bY, long cX, long cY, long dX, long dY, double p){
            double x = Math.Pow((aX+bX-cX-dX), 2);
            double y = Math.Pow((aY+bY-cY-dY), 2);
            return p * (Math.Sqrt(x+y))/100;
        }
        public double Solve(long aX, long aY, long bX, long bY, long cX, long cY, long dX, long dY)
        {
            long abMidx = (aX+bX)/2; 
            long abMidy = (aY+bY)/2; 
            long cdMidx = (cX+dX)/2; 
            long cdMidy = (cY+dY)/2; 
            double first = Solve(aX, aY, abMidx, abMidy, cX, cY, cdMidx, cdMidy);
            double second = Solve(abMidx, abMidy, bX, bY, cdMidx, cdMidy, dX, dY);
            if(first>second){
                return second;
            }
            else{ 
                return first;
            }
        }
    }
}
