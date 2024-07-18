using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);
        public class material{
            public long weight{ get; set;}
            public long value{ get; set;}
            public double vperw{ get; set;}
            public material(long w, long v, double vpw){
                weight = w; value = v; vperw = vpw;
            }
        }
        static List<material> Sort(List<material> mater){
        long l = mater.Count;
        for (int i = 0; i < l; i++)
            for(int j=i; j < l; j++){
                if(mater[j].vperw > mater[i].vperw){
                    var tmp = mater[j]; mater[j] = mater[i]; mater[i] = tmp;
                }
            }
        return mater;
}

        static long MaximumValue(long capacity, List<material> mater){
            List<material> materials = mater.OrderByDescending(x => x.vperw).ToList();
            double max=0;
            for(int i=0; i<mater.Count; i++){
                if(capacity>0){
                    double value = materials[i].vperw;
                    max += (double)Math.Min(capacity, materials[i].weight) * value;
                    capacity -= materials[i].weight;
                }
            }
            return (long)max;
        }
        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            List<material> materials = new List<material>();
            for(int i=0; i<weights.Length; i++){
                material t = new material(weights[i], values[i], (double)values[i]/weights[i]);
                materials.Add(t);
            }
            return MaximumValue(capacity, materials);
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
