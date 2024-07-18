using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long , long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] x, long[] y)
        {
            List<Tuple<long, long>> points = new List<Tuple<long, long>>();
            for(int i=0; i<n; i++){
                points.Add( new (x[i], y[i]) );
            }
            List<Tuple<long, long>> newpoints = points.OrderBy(t => t.Item1).ToList();
            return closestPoint(newpoints, 0, n-1);

        }
        public double getDist(Tuple<long, long> point1, Tuple<long, long> point2){
            double q1 = Math.Pow(point1.Item1 - point2.Item1, 2);
            double q2 = Math.Pow(point1.Item2 - point2.Item2, 2);
            return Math.Sqrt(q1+q2);
        }
        public double closestPoint(List<Tuple<long, long>> points, long start, long end){
            long len = points.Count;
            if(len <= 3){
                double min = long.MaxValue;
                for(int i=0; i<points.Count; i++){
                    for(int j=i+1; j<points.Count; j++){
                    double dist = getDist(points[i], points[j]);
                    if(dist < min)
                        min = dist;
                    }
                }
                return min;
            }
            long mid = (int) len/2;
            List<Tuple<long, long>> first = new List<Tuple<long, long>>();
            for(long i=start; i<mid; i++){
                first.Add(points[(int)i]);
            }
            List<Tuple<long, long>> second = new List<Tuple<long, long>>();
            for(long i=mid; i<len; i++){
                second.Add(points[(int)i]);
            }
            double firstHalf = closestPoint(first, start, mid);
            double secondHalf = closestPoint(second, mid+1, end);
            double mindist = Math.Min(firstHalf, secondHalf);
            List<Tuple<long, long>> middle = new List<Tuple<long, long>>();
            for(int i=0; i<len; i++){
                if(points[(int)mid].Item1-mindist <= points[i].Item1 && points[i].Item1 <= points[(int)mid].Item1+mindist)
                middle.Add(points[i]);
            }
            
            middle = middle.OrderBy(t => t.Item2).ToList();
            for(int i=0; i<middle.Count; i++){
                for(int j=i+1; j<middle.Count; j++){
                    mindist = Math.Min(mindist, getDist(middle[i], middle[j]));
                }
            }
            return  mindist;
        }
    }
}