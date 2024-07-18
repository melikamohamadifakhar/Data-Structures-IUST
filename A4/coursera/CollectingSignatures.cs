using System;
using System.Collections.Generic;

namespace CollectingSignatures
{
        public class seg{
            public int start{ get; set; }
            public int end{ get; set; }
            public seg(int s, int e){
                end = e; start = s;
            }
        }
    class Program
    {

        static List<seg> Sort(List<seg> segments, int num){
            for (int i=0; i<num; i++)
                for (int j=i; j<num; j++){
                    if(segments[i].end > segments[j].end){
                        seg s = new seg(segments[i].start, segments[i].end);
                        s = segments[i]; segments[i] = segments[j]; segments[j] = s;
                    }
                }
                return segments;
        }
        static List<int> CollectingSignatures(int num, List<seg> segments){
            List<int> result = new List<int>();
            List<seg> sortedsegments = new List<seg>();
            sortedsegments = Sort(segments, num);
            int ptr = sortedsegments[0].end;
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
        static void Main(string[] args)
        {
            int num= int.Parse(Console.ReadLine());
            List<seg> list = new List<seg>();
            for (int i=0; i<num; i++){
                string[] str = Console.ReadLine().Split();
                seg segment = new seg(int.Parse(str[0]), int.Parse(str[1]));
                list.Add(segment);
            }
            List<int> result = new List<int>();
            result = CollectingSignatures(num, list);
            System.Console.WriteLine(result.Count);
            foreach (var item in result)
                Console.Write(item + " ");
        }
    }
}
