using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);
        public class seg{
            public long start{ get; set; }
            public long end{ get; set; }
            public seg(long s, long e){
                end = e; start = s;
            }
        }
        public List<seg> Sort(List<seg> segments, long num){
            for (int i=0; i<num; i++)
                for (int j=i; j<num; j++){
                    if(segments[i].end > segments[j].end){
                        seg s = new seg(segments[i].start, segments[i].end);
                        s = segments[i]; segments[i] = segments[j]; segments[j] = s;
                    }
                }
                return segments;
        }
        public List<long> CollectingSignatures(long num, List<seg> segments){
            List<long> result = new List<long>();
            List<seg> sortedsegments = new List<seg>();
            sortedsegments = Sort(segments, num);
            long ptr = sortedsegments[0].end;
            for (int i=0; i<sortedsegments.Count; i++){
                if(sortedsegments[i].start <= ptr && ptr <= sortedsegments[i].end){
                        sortedsegments.Remove(sortedsegments[i]);
                    if(!result.Contains(ptr))
                            result.Add(ptr);
                    }
                else{ ptr=sortedsegments[0].end; } 
                i--;
                
            }
            return result;
        }
        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<seg> list = new List<seg>();
            for (long i=0; i<tenantCount; i++){
                seg segment = new seg(startTimes[i], endTimes[i]);
                list.Add(segment);
            }
            return CollectingSignatures(tenantCount, list).Count;
        }
    }
}
